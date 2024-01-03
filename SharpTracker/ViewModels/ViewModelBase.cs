using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using CommunityToolkit.Mvvm.ComponentModel;

namespace SharpTracker.ViewModels;

public class ViewModelBase : ObservableObject
{
    /// <summary>
    /// Creates a new ObservableCollection of <typeparamref name="TDestinationViewModelCollection"/>, and populates it with the ViewModel representation of <typeparamref name="TSourceModelCollection"/>
    /// </summary>
    /// <param name="source">The collection to be loaded into an ObservableCollection</param>
    /// <typeparam name="TSourceModelCollection">An IEnumerable collection of models. Currently only supports lists</typeparam>
    /// <typeparam name="TDestinationViewModelCollection">A ViewModel collection</typeparam>
    /// <returns>A new ObservableCollection of <typeparamref name="TDestinationViewModelCollection"/></returns>
    /// <exception cref="InvalidOperationException">Throws if the method can't find a constructor for <typeparamref name="TDestinationViewModelCollection"/> with one argument</exception>
    public static ObservableCollection<TDestinationViewModelCollection> LoadCollection
        <TSourceModelCollection, TDestinationViewModelCollection>
        (IEnumerable<TSourceModelCollection> source) where TSourceModelCollection : class
    {
        var viewModelType = typeof(TDestinationViewModelCollection);
        var viewModelTypeConstructor = viewModelType.GetConstructor(new[] { typeof(TSourceModelCollection) }) ?? throw new InvalidOperationException(
                $"No constructor found in {viewModelType.Name} that takes a single argument of type {typeof(TSourceModelCollection).Name}");
        return new ObservableCollection<TDestinationViewModelCollection>(source.Select(modelCollection =>
            (TDestinationViewModelCollection)viewModelTypeConstructor.Invoke(new object[]
                { modelCollection })));
    }
}
