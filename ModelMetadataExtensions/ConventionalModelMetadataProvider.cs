using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using ModelMetadataExtensions.Extensions;

namespace ModelMetadataExtensions {
    public class ConventionalModelMetadataProvider : DataAnnotationsModelMetadataProvider {
        public ConventionalModelMetadataProvider(bool requireConventionAttribute)
            : this(requireConventionAttribute, null) {
        }

        public ConventionalModelMetadataProvider(bool requireConventionAttribute, Type defaultResourceType) {
            RequireConventionAttribute = requireConventionAttribute;
            DefaultResourceType = defaultResourceType;
        }

        // Whether or not the conventions only apply to classes with the MetadatawonventionsAttribute attribute applied.
        public bool RequireConventionAttribute {
            get;
            private set;
        }

        // Whether or not the conventions only apply to classes with the MetadataConventionsAttribute attribute applied.
        public Type DefaultResourceType {
            get;
            private set;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName) {
            Func<IEnumerable<Attribute>, ModelMetadata> metadataFactory = (attr) => base.CreateMetadata(attr, containerType, modelAccessor, modelType, propertyName);

            var conventionType = containerType ?? modelType;

            Type defaultResourceType = DefaultResourceType;
            MetadataConventionsAttribute conventionAttribute = conventionType.GetAttributeOnTypeOrAssembly<MetadataConventionsAttribute>();
            if (conventionAttribute != null && conventionAttribute.ResourceType != null) {
                defaultResourceType = conventionAttribute.ResourceType;
            }
            else if (RequireConventionAttribute) {
                return metadataFactory(attributes);
            }

            ApplyConventionsToValidationAttributes(attributes, containerType, propertyName, defaultResourceType);

            var foundDisplayAttribute = attributes.FirstOrDefault(a => typeof(DisplayAttribute) == a.GetType()) as DisplayAttribute;

            if (foundDisplayAttribute.CanSupplyDisplayName()) {
                return metadataFactory(attributes);
            }

            // Our displayAttribute is lacking. Time to get busy.
            DisplayAttribute displayAttribute = foundDisplayAttribute.Copy() ?? new DisplayAttribute();

            var rewrittenAttributes = attributes.Replace(foundDisplayAttribute, displayAttribute);

            // ensure resource type.
            displayAttribute.ResourceType = displayAttribute.ResourceType ?? defaultResourceType;

            if (displayAttribute.ResourceType != null) {
                // ensure resource name
                string displayAttributeName = GetDisplayAttributeName(containerType, propertyName, displayAttribute);
                if (displayAttributeName != null) {
                    displayAttribute.Name = displayAttributeName;
                }
                if (!displayAttribute.ResourceType.PropertyExists(displayAttribute.Name)) {
                    displayAttribute.ResourceType = null;
                }
            }

            var metadata = metadataFactory(rewrittenAttributes);
            if (metadata.DisplayName == metadata.PropertyName) {
                metadata.DisplayName = metadata.DisplayName.SplitUpperCaseToString();
            }
            return metadata;
        }

        private static void ApplyConventionsToValidationAttributes(IEnumerable<Attribute> attributes, Type containerType, string propertyName, Type defaultResourceType) {
            foreach (ValidationAttribute validationAttribute in attributes.Where(a => (a as ValidationAttribute != null))) {
                if (string.IsNullOrEmpty(validationAttribute.ErrorMessage)) {
                    string attributeShortName = validationAttribute.GetType().Name.Replace("Attribute", "");
                    string resourceKey = GetResourceKey(containerType, propertyName) + "_" + attributeShortName;

                    var resourceType = validationAttribute.ErrorMessageResourceType ?? defaultResourceType;

                    if (!resourceType.PropertyExists(resourceKey)) {
                        resourceKey = "Error_" + attributeShortName;
                        if (!resourceType.PropertyExists(resourceKey)) {
                            continue;
                        }

                        validationAttribute.ErrorMessageResourceType = resourceType;
                        validationAttribute.ErrorMessageResourceName = resourceKey;
                    }
                }
            }
        }

        private static string GetDisplayAttributeName(Type containerType, string propertyName, DisplayAttribute displayAttribute) {
            if (containerType != null) {
                if (String.IsNullOrEmpty(displayAttribute.Name)) {
                    // check to see that resource key exists.
                    string resourceKey = GetResourceKey(containerType, propertyName);
                    if (displayAttribute.ResourceType.PropertyExists(resourceKey)) {
                        return resourceKey;
                    }
                    else {
                        return propertyName;
                    }
                }

            }
            return null;
        }

        private static string GetResourceKey(Type containerType, string propertyName) {
            return containerType.Name + "_" + propertyName;
        }

    }

}