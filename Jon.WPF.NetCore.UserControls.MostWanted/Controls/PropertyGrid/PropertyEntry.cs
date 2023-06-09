﻿using System.ComponentModel;

namespace Jon.WPF.NetCore.UserControls.MostWanted.Controls.PropertyGrid
{
    public class PropertyEntry
    {
        public PropertyDescriptor? PropertyDescriptor { get; }
        public object? Instance { get; }
        public bool IsCategory { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public string Description
        {
            get { return PropertyDescriptor != null ? PropertyDescriptor.Description : string.Empty; }
        }
        public object? Value
        {
            get { return PropertyDescriptor?.GetValue(Instance); }
            set { PropertyDescriptor?.SetValue(Instance, value); }
        }
        public PropertyEntry()
        { }
        public PropertyEntry(PropertyDescriptor propertyDescriptor, object instance, string? category = null)
        {
            PropertyDescriptor = propertyDescriptor;
            Instance = instance;
            Category = category;
            Name = propertyDescriptor.Name;
        }
    }
}