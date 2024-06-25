<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128638677/10.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2254)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Property Grid - Filter object properties (CustomPropertyDescriptors event)

This example handles the Property Grid's [CustomPropertyDescriptors](https://docs.devexpress.com/WindowsForms/DevExpress.XtraVerticalGrid.PropertyGridControl.CustomPropertyDescriptors) event to display properties based on a condition.

The example displays Dock, Size, and Location properties at the root. For the Size property, the example displays the `Height` property.

```csharp
void propertyGridControl1_CustomPropertyDescriptors(object sender, CustomPropertyDescriptorsEventArgs e) {
    // Specifies properties to display at the root level.
    if(e.Context.PropertyDescriptor == null) {
        PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
        AddIfPropertyExist(e.Properties, filteredCollection, "Dock");
        AddIfPropertyExist(e.Properties, filteredCollection, "Size");
        AddIfPropertyExist(e.Properties, filteredCollection, "Location");
        AddIfPropertyExist(e.Properties, filteredCollection, "NonexistentProperty");
        e.Properties = filteredCollection;
    }
    // Specifies nested properties for the Size property.
    if(e.Context.PropertyDescriptor != null && e.Context.PropertyDescriptor.Name == "Size") {
        PropertyDescriptorCollection filteredCollection = new PropertyDescriptorCollection(null);
        AddIfPropertyExist(e.Properties, filteredCollection, "Height");
        e.Properties = filteredCollection;
    }
}
```


## Files to Review

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-propertygrid-filter-object-properties&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-propertygrid-filter-object-properties&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
