﻿// From https://github.com/CommunityToolkit/dotnet/blob/main/src/CommunityToolkit.Mvvm/Input/RelayCommand.cs

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// This file is inspired from the MvvmLight library (lbugnion/MvvmLight),
// more info in ThirdPartyNotices.txt in the root of the project.

using System;
using System.Runtime.CompilerServices;
using CustomerDetails.Interfaces.Input;

namespace CustomerDetails.Input;

/// <summary>
/// A command whose sole purpose is to relay its functionality to other
/// objects by invoking delegates. The default return value for the <see cref="CanExecute"/>
/// method is <see langword="true"/>. This type does not allow you to accept command parameters
/// in the <see cref="Execute"/> and <see cref="CanExecute"/> callback methods.
/// </summary>
public sealed partial class RelayCommand : IRelayCommand
{
    /// <summary>
    /// The <see cref="Action"/> to invoke when <see cref="Execute"/> is used.
    /// </summary>
    private readonly Action execute;

    /// <summary>
    /// The optional action to invoke when <see cref="CanExecute"/> is used.
    /// </summary>
    private readonly Func<bool>? canExecute;

    /// <inheritdoc/>
    public event EventHandler? CanExecuteChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class that can always execute.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="execute"/> is <see langword="null"/>.</exception>
    public RelayCommand(Action execute)
    {
        ArgumentNullException.ThrowIfNull(execute);

        this.execute = execute;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="RelayCommand"/> class.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <param name="canExecute">The execution status logic.</param>
    /// <exception cref="System.ArgumentNullException">Thrown if <paramref name="execute"/> or <paramref name="canExecute"/> are <see langword="null"/>.</exception>
    public RelayCommand(Action execute, Func<bool> canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute);
        ArgumentNullException.ThrowIfNull(canExecute);

        this.execute = execute;
        this.canExecute = canExecute;
    }

    /// <inheritdoc/>
    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <inheritdoc/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool CanExecute(object? parameter)
    {
        return this.canExecute?.Invoke() != false;
    }

    /// <inheritdoc/>
    public void Execute(object? parameter)
    {
        this.execute();
    }
}