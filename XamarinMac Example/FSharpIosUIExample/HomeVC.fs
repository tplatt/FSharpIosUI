namespace FSharpIosUIExample
open System
open Foundation
open AppKit

module Helpers =
    let getElementInViews(views:NSView[], name:String) =
        views |> Array.filter(fun v -> String.Compare(v.Identifier, name) = 0)
              |> Array.head

[<Register ("HomeVC")>]
type HomeVC =
    inherit NSViewController

    new (handle : IntPtr) = { inherit NSViewController (handle) }

    [<Export ("initWithCoder:")>]
    new (coder : NSCoder) = { inherit NSViewController (coder) }

    member x.getElement name =
        Helpers.getElementInViews(x.View.Subviews, name)


    member x.ClickMeButton = x.getElement( "SomeButton" ):?> NSButton
    member x.ClickLabel = x.getElement( "InfoLabel" ) :?> NSTextField

    member x.updateLabel(e:EventArgs) =
        x.ClickLabel.StringValue <- "Button was clicked"


    override x.ViewDidLoad() =
        x.ClickMeButton.Activated |> Observable.subscribe(x.updateLabel) |> ignore

