using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

public static class VisualTreeExtensions
{
    public static List<T> GetChildrenByType<T>(this UIElement element)
        where T : UIElement
    {
        return GetChildrenByType<T>(element, null);
    }

    public static bool HasChildrenByType<T>(this UIElement element, Func<T, bool> condition)
        where T : UIElement
    {
        return GetChildrenByType(element, condition).Count != 0;
    }

    public static List<T> GetChildrenByType<T>(this UIElement element, Func<T, bool> condition)
        where T : UIElement
    {
        var results = new List<T>();
        GetChildrenByType(element, condition, results);
        return results;
    }

    private static void GetChildrenByType<T>(UIElement element, Func<T, bool> condition, List<T> results)
        where T : UIElement
    {
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
        {
            var child = VisualTreeHelper.GetChild(element, i) as UIElement;
            if (child != null)
            {
                var t = child as T;
                if (t != null)
                {
                    if (condition == null)
                        results.Add(t);
                    else if (condition(t))
                        results.Add(t);
                }
                GetChildrenByType(child, condition, results);
            }
        }
    }


    public static IEnumerable<DependencyObject> Descendents(this DependencyObject root)
    {
        int count = VisualTreeHelper.GetChildrenCount(root);
        for (int i = 0; i < count; i++)
        {
            DependencyObject child = VisualTreeHelper.GetChild(root, i);
            yield return child;
            foreach (DependencyObject descendent in Descendents(child))
                yield return descendent;
        }
    }
}