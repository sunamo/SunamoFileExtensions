namespace SunamoFileExtensions._sunamo;

/// <summary>
/// Helper methods for working with dictionaries
/// </summary>
internal class DictionaryHelper
{
    #region AddOrCreate when key and value are not list
    /// <summary>
    /// Adds a value to a dictionary with list values, creating a new list if the key doesn't exist
    /// </summary>
    /// <typeparam name="TKey">The type of the dictionary key</typeparam>
    /// <typeparam name="TValue">The type of the values in the list</typeparam>
    /// <typeparam name="TCollectionType">The inner type of collection entries for IList keys</typeparam>
    /// <param name="dict">The dictionary to add to</param>
    /// <param name="key">The key to add the value under</param>
    /// <param name="value">The value to add</param>
    /// <param name="isWithoutDuplicatesInValue">If true, prevents duplicate values in the list</param>
    /// <param name="stringComparisonDict">Optional dictionary for string comparison</param>
    internal static void AddOrCreate<TKey, TValue, TCollectionType>(IDictionary<TKey, List<TValue>> dict, TKey key, TValue value,
    bool isWithoutDuplicatesInValue = false, Dictionary<TKey, List<string>>? stringComparisonDict = null)
        where TKey : notnull
    {
        var isComparingWithString = false;
        if (stringComparisonDict != null) isComparingWithString = true;
        if (key is IList && typeof(TCollectionType) != typeof(Object))
        {
            var keyEnumerable = key as IList<TCollectionType>;
            var isContains = false;
            foreach (var item in dict)
            {
                var keyDict = item.Key as IList<TCollectionType>;
                if (keyDict != null && keyEnumerable != null && keyDict.SequenceEqual(keyEnumerable)) isContains = true;
            }
            if (isContains)
            {
                foreach (var item in dict)
                {
                    var keyDict = item.Key as IList<TCollectionType>;
                    if (keyDict != null && keyEnumerable != null && keyDict.SequenceEqual(keyEnumerable))
                    {
                        if (isWithoutDuplicatesInValue)
                            if (item.Value.Contains(value))
                                return;
                        item.Value.Add(value);
                    }
                }
            }
            else
            {
                List<TValue> newList = new();
                newList.Add(value);
                dict.Add(key, newList);
                if (isComparingWithString && stringComparisonDict != null)
                {
                    List<string> newStringList = new();
                    var valueString = value?.ToString();
                    if (valueString != null)
                    {
                        newStringList.Add(valueString);
                        stringComparisonDict.Add(key, newStringList);
                    }
                }
            }
        }
        else
        {
            var shouldAdd = true;
            lock (dict)
            {
                if (dict.ContainsKey(key))
                {
                    if (isWithoutDuplicatesInValue)
                    {
                        if (dict[key].Contains(value))
                            shouldAdd = false;
                        else if (isComparingWithString && stringComparisonDict != null)
                        {
                            var valueString = value?.ToString();
                            if (valueString != null && stringComparisonDict[key].Contains(valueString))
                                shouldAdd = false;
                        }
                    }
                    if (shouldAdd)
                    {
                        var existingValue = dict[key];
                        if (existingValue != null) existingValue.Add(value);
                        if (isComparingWithString && stringComparisonDict != null)
                        {
                            var existingStringValue = stringComparisonDict[key];
                            var valueString = value?.ToString();
                            if (existingStringValue != null && valueString != null)
                                existingStringValue.Add(valueString);
                        }
                    }
                }
                else
                {
                    if (!dict.ContainsKey(key))
                    {
                        List<TValue> newList = new();
                        newList.Add(value);
                        dict.Add(key, newList);
                    }
                    else
                    {
                        dict[key].Add(value);
                    }
                    if (isComparingWithString && stringComparisonDict != null)
                    {
                        var valueString = value?.ToString();
                        if (valueString != null)
                        {
                            if (!stringComparisonDict.ContainsKey(key))
                            {
                                List<string> newStringList = new();
                                newStringList.Add(valueString);
                                stringComparisonDict.Add(key, newStringList);
                            }
                            else
                            {
                                stringComparisonDict[key].Add(valueString);
                            }
                        }
                    }
                }
            }
        }
    }

    /// <summary>
    /// Adds a value to a dictionary with list values, creating a new list if the key doesn't exist
    /// If dictionary already contains a group with the specified key, adds the value to that group
    /// Otherwise creates a new group with the key and value
    /// </summary>
    /// <typeparam name="TKey">The type of the dictionary key</typeparam>
    /// <typeparam name="TValue">The type of the values in the list</typeparam>
    /// <param name="dict">The dictionary to add to</param>
    /// <param name="key">The key to add the value under</param>
    /// <param name="value">The value to add</param>
    /// <param name="isWithoutDuplicatesInValue">If true, prevents duplicate values in the list</param>
    /// <param name="stringComparisonDict">Optional dictionary for string comparison</param>
    internal static void AddOrCreate<TKey, TValue>(IDictionary<TKey, List<TValue>> dict, TKey key, TValue value,
    bool isWithoutDuplicatesInValue = false, Dictionary<TKey, List<string>>? stringComparisonDict = null)
        where TKey : notnull
    {
        AddOrCreate<TKey, TValue, object>(dict, key, value, isWithoutDuplicatesInValue, stringComparisonDict);
    }
    #endregion
}
