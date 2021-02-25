#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"

open Html

let about = "F# is a strongly-typed, functional-first programming language for writing simple code to solve complex problems. From the business perspective, the primary role of F# is to reduce the time-to-deployment for robust software in the modern enterprise and web applications."

let generate' (ctx : SiteContents) (_: string) =
  let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
  let desc =
    siteInfo
    |> Option.map (fun si -> si.description)
    |> Option.defaultValue ""

  // Anything passed here will go to layout.fsx to be generated in the middle of the page.
  Layout.layout ctx "About" [
    div [Class "container"] [
      div [Class "mature"] [
        div [Class "container"] [
          div [Class "mature-in"] [
            div [Class "mature-blk"] [
              p [] [ !!"About F#" ]
            ]
          ]
        ]
        div [Class "cross-in"] [
          div [Class "cross-lft"] [
            p [] [
                !! about
            ]
          ]
        ]
        div [Class "cross-in"] [
          div [Class "cross-lft"] [
            p [] [
                !! "We have this blank space in our existing 'about' page"
            ]
          ]
        ]
        div [Class "mature-in"] [
          div [Class "mature-blk"] [
            p [] [ 
              a [ Href "https://dotnet.microsoft.com/languages/fsharp" ] [ !! "F# Language at Microsoft" ] ]
          ]
        ]
        div [Class "cross-in"] [
          div [Class "cross-lft"] [
            p [] [
                !! "A simple, clear resource explaining what F# is and what it is for, provided by a major commercial contributor to F# and its tooling. Learn about the tools for F#, the F# community, using F# with the .NET platform and access getting-started material."
            ]
          ]
        ]
        div [Class "cross-in"] [
          div [Class "cross-lft"] [
            p [] [
                !! "We have this blank space in our existing 'about' page"
            ]
          ]
        ]
        div [Class "mature-in"] [
          div [Class "mature-blk"] [
            p [] [ 
              a [ Href "http://fsharpforfunandprofit.com/" ] [ !! "F# for C#, Java or Python developers" ] ]
          ]
        ]
        div [Class "cross-in"] [
          div [Class "cross-lft"] [
            p [] [
                !! "Introduces you to F# and show you ways that F# can help in day-to-day development of mainstream commercial business software."
            ]
          ]
        ]
      ]
    ]
  ]

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
  generate' ctx page
  |> Layout.render ctx