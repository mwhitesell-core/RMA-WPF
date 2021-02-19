using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

public static class DependencyObjectExtensions
{

    public static IEnumerable<T> FindVisualChildrens<T>(this DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(depObj) - 1; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                    yield return (T)child;

                foreach (T childOfChild in FindVisualChildrens<T>(child))
                    yield return childOfChild;
            }
        }
    }

    public static List<T> GetChildrenByType<T>(this UIElement element, Func<T, bool> condition) where T : UIElement
    {
        var results = new List<T>();
        GetChildrenByType1(element, condition, results);
        return results;
    }

    private static void GetChildrenByType1<T>(this UIElement element, Func<T, bool> condition, List<T> results) where T : UIElement
    {
        for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(element) - 1; i++)
        {
            var child = VisualTreeHelper.GetChild(element, i) as UIElement;
            if (child != null)
            {
                var ct = child as T;
                if (ct != null)
                {
                    if (condition == null)
                        results.Add(ct);
                    else if (condition(ct))
                        results.Add(ct);
                }
                GetChildrenByType1(child, condition, results);
            }
        }
    }
 



}