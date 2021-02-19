using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace rma.Helpers
{
    internal static class CoreHelper
    {
        public static bool IsNullOrWhiteSpace(string value)
        {
            if (value != null)
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsWhiteSpace(value[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        internal static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<TKey> source,
                                                                            Func<TKey, TValue> converter)
        {
            var result = new Dictionary<TKey, TValue>();
            foreach (TKey item in source)
            {
                result[item] = converter(item);
            }
            return result;
        }

        internal static IEnumerable<T> TrimEnd<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            var buffer = new List<T>();
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    buffer.Add(item);
                }
                else
                {
                    foreach (T bufferItem in buffer)
                    {
                        yield return bufferItem;
                    }
                    yield return item;
                    buffer.Clear();
                }
            }
        }

        internal static int GetCombinedHashCode(params object[] objects)
        {
            int combinedHash = 271;
            for (int i = 0; i < objects.Length; ++i)
            {
                if (objects[i] != null)
                {
                    combinedHash *= 31;
                    combinedHash += objects[i].GetHashCode();
                }
            }
            return combinedHash;
        }

        internal static IEnumerable<string> Split(this string source, Func<char, bool> shouldSplitCallback)
        {
            var sb = new StringBuilder();
            for (int i = 0, l = source.Length; i < l; ++i)
            {
                if (shouldSplitCallback(source[i]))
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
                else
                {
                    sb.Append(source[i]);
                }
            }
            yield return sb.ToString();
        }

        internal static string CleanUpNewLines(string str)
        {
            var result = new StringBuilder(str.Length);
            bool hasSeenCr = false;

            for (int i = 0, l = str.Length; i < l; ++i)
            {
                if (str[i] == '\r')
                {
                    if (hasSeenCr)
                    {
                        result.Append(DocumentEnvironment.NewLine);
                    }

                    hasSeenCr = true;
                }
                else if (str[i] == '\n')
                {
                    result.Append(DocumentEnvironment.NewLine);
                    hasSeenCr = false;
                }
                else
                {
                    if (hasSeenCr)
                    {
                        result.Append(DocumentEnvironment.NewLine);
                        hasSeenCr = false;
                    }

                    result.Append(str[i]);
                }
            }

            if (hasSeenCr)
            {
                result.Append(DocumentEnvironment.NewLine);
            }

            return result.ToString();
        }

        internal static DependencyObject GetFocusedElement(UIElement element)
        {
            return (DependencyObject) FocusManager.GetFocusedElement(FocusManager.GetFocusScope(element));
        }

        /// <summary>
        /// Get bounding rectangle around transformed one.
        /// </summary>
        /// <param name="rect">Rectangle that is to be rotated</param>
        /// <param name="matrix">Transform matrix</param>
        /// <returns>the bounding rectangle around <paramref name="rect"/>
        /// that is transformed with <paramref name="matrix"/>.</returns>
        //public static RectangleF GetBoundingRect(RectangleF rect, RadMatrix matrix)
        //{
        //    if (matrix.IsIdentity)
        //    {
        //        return rect;
        //    }

        //    var points = new Point[4];
        //    points[0] = new Point(rect.Left, rect.Top);
        //    points[1] = new Point(rect.Right, rect.Top);
        //    points[2] = new Point(rect.Right, rect.Bottom);
        //    points[3] = new Point(rect.Left, rect.Bottom);

        //    TransformPoints(points, matrix.Elements);

        //    double left = Math.Min(Math.Min(points[0].X, points[1].X), Math.Min(points[2].X, points[3].X));
        //    double right = Math.Max(Math.Max(points[0].X, points[1].X), Math.Max(points[2].X, points[3].X));
        //    double top = Math.Min(Math.Min(points[0].Y, points[1].Y), Math.Min(points[2].Y, points[3].Y));
        //    double bottom = Math.Max(Math.Max(points[0].Y, points[1].Y), Math.Max(points[2].Y, points[3].Y));

        //    return RectangleF.FromLTRB(left, top, right, bottom);
        //}

        public static void TransformPoints(Point[] points, float[] elements)
        {
            for (int i = 0; i < points.Length; i++)
            {
                double x = points[i].X;
                double y = points[i].Y;

                points[i].X = (x*elements[0]) + (y*elements[2]) + elements[4];
                points[i].Y = (x*elements[1]) + (y*elements[3]) + elements[5];
            }
        }

        internal static IEnumerable<T> LayoutBoxIterator<T>(RadDocument document) where T : LayoutBox
        {
            return LayoutBoxIterator<T>(document.DocumentLayoutBox);
        }

        internal static IEnumerable<T> LayoutBoxIterator<T>(LayoutBox layoutBox) where T : LayoutBox
        {
            foreach (LayoutBox childBox in layoutBox.ChildLayoutBoxes)
            {
                if (childBox is T)
                {
                    yield return (T) childBox;
                }
                else
                {
                    foreach (T subBox in LayoutBoxIterator<T>(childBox))
                    {
                        yield return subBox;
                    }
                }
            }
        }
    }
}