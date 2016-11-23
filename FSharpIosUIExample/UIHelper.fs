namespace UIHelperFunctions

open System
open UIKit
open Foundation

module UIHelper =

    let getElementInViews(views:UIView[], name:String) =
        views |> Array.filter(fun v -> String.Compare(v.AccessibilityIdentifier, name) = 0)
              |> Array.head