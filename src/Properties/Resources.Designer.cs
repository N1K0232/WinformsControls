﻿using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace WinformsControls.Properties;

/// <summary>
/// A strongly-typed resource class, for looking up localized strings, etc.
/// </summary>
// This class was auto-generated by the StronglyTypedResourceBuilder
// class via a tool like ResGen or Visual Studio.
// To add or remove a member, edit your .ResX file then rerun ResGen
// with the /str option, or rebuild your VS project.
[GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
[DebuggerNonUserCodeAttribute()]
[CompilerGeneratedAttribute()]
internal sealed partial class Resources
{
    private static ResourceManager _resourceManager;
    private static CultureInfo _resourceCulture;

    /// <summary>
    /// creates a new instance of the <see cref="Resources"/> class
    /// this constructor is no needed because the methods are static
    /// </summary>
    [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    internal Resources()
    {
    }

    
    /// <summary>
    /// gets the ResourceManager
    /// </summary>
    internal static ResourceManager ResourceManager
    {
        get
        {
            if(object.ReferenceEquals(_resourceManager, null))
            {
                Type currentType = typeof(Resources);
                ResourceManager resourceManager = new("WinformsControls.Properties.Resources", currentType.Assembly);
                _resourceManager = resourceManager;           
            }

            return _resourceManager;
        }
    }

    /// <summary>
    /// gets or sets the culture for this object
    /// </summary>
    internal static CultureInfo Culture
    {
        get => _resourceCulture;
        set => _resourceCulture = value;
    }

    /// <summary>
    /// gets the CalendarDark image object
    /// </summary>
    internal static Image CalendarDark
    {
        get
        {
            string resourceName = nameof(CalendarDark);
            bool found = TryGetResource(resourceName, out object resource);
            
            if(found && resource is Bitmap calendarDark)
            {
                return calendarDark;
            }

            return null;
        }
    }

    /// <summary>
    /// gets a CalendarWhite image object
    /// </summary>
    internal static Image CalendarWhite
    {
        get
        {
            string resourceName = nameof(CalendarWhite);
            bool found = TryGetResource(resourceName, out object resource);

            if(found && resource is Bitmap calendarWhite)
            {
                return calendarWhite;
            }

            return null;
        }
    }

    /// <summary>
    /// gets the a resource located in the Resources folder
    /// this method is accessible only for this library
    /// </summary>
    /// <param name="resourceName">the name of the resource</param>
    /// <returns>the resource object found otherwise <see langword="null"/>/></returns>
    internal static object GetResource(string resourceName)
    {
        bool found = TryGetResource(resourceName, out object resource);
        if(found)
        {
            return resource;
        }

        return null;
    }

    /// <summary>
    /// performs all the operations to get the resource located in the Resources folder
    /// </summary>
    /// <param name="resourceName">the name of the resource</param>
    /// <param name="resource">the resource object found</param>
    /// <returns><see langword="true"/> if the resource was found otherwise <see langword="false"/></returns>
    private static bool TryGetResource(string resourceName, out object resource)
    {
        if(string.IsNullOrWhiteSpace(resourceName))
        {
            resource = null;
            return false;
        }

        
        ResourceManager manager = ResourceManager;
        CultureInfo culture = Culture;
        
        resource = manager.GetObject(resourceName, culture);
        return resource != null;
    }
}