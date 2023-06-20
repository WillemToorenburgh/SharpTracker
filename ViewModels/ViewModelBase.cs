using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using ReactiveUI;

namespace SharpTracker.ViewModels;

// Switched away from ReactiveUI ReactiveObject to try CommunityToolkit.Mvvm's ObservableObject
public class ViewModelBase : ReactiveObject
{
    /// <summary>
    /// Creates a new AvaloniaList of <typeparamref name="TDestinationViewModelCollection"/>, and populates it with the ViewModel representation of <typeparamref name="TSourceModelCollection"/>
    /// </summary>
    /// <param name="source">The collection to be loaded into an AvaloniaList</param>
    /// <typeparam name="TSourceModelCollection">An IEnumerable collection of models. Currently only supports lists</typeparam>
    /// <typeparam name="TDestinationViewModelCollection">A ViewModel collection</typeparam>
    /// <returns>A new AvaloniaList of <typeparamref name="TDestinationViewModelCollection"/></returns>
    /// <exception cref="InvalidOperationException">Throws if the method can't find a constructor for <typeparamref name="TDestinationViewModelCollection"/> with one argument</exception>
    public static AvaloniaList<TDestinationViewModelCollection> LoadCollection
        <TSourceModelCollection, TDestinationViewModelCollection>
        (IEnumerable<TSourceModelCollection> source) where TSourceModelCollection : class
    {
        var viewModelType = typeof(TDestinationViewModelCollection);
        var viewModelTypeConstructor = viewModelType.GetConstructor(new[] { typeof(TSourceModelCollection) });
        if (viewModelTypeConstructor == null)
            throw new InvalidOperationException(
                $"No constructor found in {viewModelType.Name} that takes a single argument of type {typeof(TSourceModelCollection).Name}");
        return new AvaloniaList<TDestinationViewModelCollection>(source.Select(modelCollection =>
            (TDestinationViewModelCollection)viewModelTypeConstructor.Invoke(new object[]
                { modelCollection })));
    }
}
