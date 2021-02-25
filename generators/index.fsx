#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"

open Html

let generate' (ctx : SiteContents) (_: string) =
  let posts = ctx.TryGetValues<Postloader.Post> () |> Option.defaultValue Seq.empty
  let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
  let desc =
    siteInfo
    |> Option.map (fun si -> si.description)
    |> Option.defaultValue ""

  let psts =
    posts
    |> Seq.sortByDescending Layout.published
    |> Seq.toList
    |> List.map (Layout.postLayout true)

  // Anything passed here will go to layout.fsx to be generated in the middle of the page.
  Layout.layout ctx "Home" [
    div [Class "container"] [
      section [Class "articles"] [
        div [Class "column is-8 is-offset-2"] [
            div [Class "mature"] [
              div [Class "container"] [
                div [Class "mature-in"] [
                  div [Class "mature-blk"] [
                    p [] [ !!"F# is a mature, open source, cross-platform,"; br []; !!"functional-first programming language" ]
                  ]
                ]
              ]
            ]
            div [Class "cross"] [
              div [Class "container"] [
                div [Class "cross-in"] [
                  div [Class "cross-lft"] [
                    p [] [
                      !!"F# runs on Linux, Mac OS X, Android, iOS,"
                      br []
                      !!"Windows, GPUs, and browsers. It is free to use and is"
                      br []
                      !!"open sourceunder an OSI-approved"
                      br []
                      !! "license."
                    ]
                    p [] [
                      !!"F# is used in a wide range of application areas and is"
                      br []
                      !!"supported by both an active open"
                      br []
                      !!"community and industry-leading companies"
                      br []
                      !!"providing professional tools."
                    ]
                    ul [] [
                      li [] [ a [Href "#"] [!! "Getting Started"] ]
                      li [] [ a [Href "#"] [!! "Install F#"] ]
                    ]
                  ]
                  div [Class "cross-rgt"] [
                    div [Class "cross-main"] [
                      p [] [
                        !!"// Declare a local value (inferred type is string)"
                        br []
                        !!"let world = \"world\""
                        br []
                        !!"// Using '%s' format specifier to include string"
                        br []
                        !!"parameter"
                        br []
                        !!"printfn \"Hello %s!\" world"
                      ]
                      div [Class "cross-txt"] [
                        a [Href "#"] [!!"RUN"]
                      ]
                    ]
                  ]
                  div [Class "clear"] []
                ]
              ]
              
            ]
            div [Class "high"] [
              div [Class "container"] [
                div [Class "high-in"] [
                  ul [] [
                    li [] [
                      div [Class "high-blk"] [
                        h3 [] [ !!"highlight #1" ]
                        p [] [!!"Lorem ipsum dolor sit amet, consectetuer adipiscing elit."]
                      ]
                    ]
                    li [] [
                      div [Class "high-blk"] [
                        h3 [] [ !!"highlight #2" ]
                        p [] [!!"Lorem ipsum dolor sit amet, consectetuer adipiscing elit."]
                      ]
                    ]
                    li [] [
                      div [Class "high-blk"] [
                        h3 [] [ !!"highlight #3" ]
                        p [] [!!"Lorem ipsum dolor sit amet, consectetuer adipiscing elit."]
                      ]
                    ]
                  ]
                ]
              ]
            ]
            div [Class "case"] [
              div [Class "container"] [
                div [Class "case-in"] [
                  h4 [] [!!"case studies"]
                ]
              ]
            ]
            div [Class "studies"] [
              ul [] [
                li [] [
                  figure [] [
                    img [Src "images/small-img1.jpg"; Alt "img"; Width "500"; Height "236"]
                  ]
                ]
                li [] [
                  figure [] [
                    img [Src "images/small-img2.png"; Alt "img"; Width "500"; Height "236"]
                  ]
                ]
                li [] [
                  figure [] [
                    img [Src "images/shap-img3.png"; Alt "img"; Width "500"; Height "236"]
                  ]
                ]
              ]
            ]
            div [Class "slider"] [
              div [Class "louvre"] [
                div [Class "container"] [
                  div [Class "louvre-in"] [
                    h3 [] [!!"LouVRe - abu dhabi"]
                    p [] [!!"Goswin Rothenthal used F# and Rhinoceros3D to construct an associative digital 3D model for the manufacturing of the Cladding of the Louvre Abu Dhabi Dome"]
                    a [Href "#"] [!!"READ testimonials"]
                  ]
                ]
              ]
              div [Class "louvre"] [
                div [Class "container"] [
                  div [Class "louvre-in"] [
                    h3 [] [!!"LouVRe - abu dhabi"]
                    p [] [!!"Goswin Rothenthal used F# and Rhinoceros3D to construct an associative digital 3D model for the manufacturing of the Cladding of the Louvre Abu Dhabi Dome"]
                    a [Href "#"] [!!"READ testimonials"]
                  ]
                ]
              ]
            ]
            div [Class "sponsors"] [
              div [Class "container"] [
                div [Class "sponsors-in"] [
                  h4 [] [!!"SPONSORS"]
                ]
                ul [] [
                  li [] [a [Href "#"] [img [Src "images/icon1.png"; Alt "img"; Width "183"; Height "74"] ]]
                  li [] [a [Href "#"] [img [Src "images/icon2.png"; Alt "img"; Width "183"; Height "74"] ]]
                  li [] [a [Href "#"] [img [Src "images/icon3.png"; Alt "img"; Width "183"; Height "74"] ]]
                  li [] [a [Href "#"] [img [Src "images/icon4.png"; Alt "img"; Width "183"; Height "74"] ]]
                  li [] [a [Href "#"] [img [Src "images/icon5.png"; Alt "img"; Width "183"; Height "74"] ]]
                ]
              ]
              div [Class "back-to-top"] [
                a [Href "#"; Class "scrollToTop"] [i [Class "fas fa-angle-up"] []]
              ]
            ]
        ]
      ]
    ]
  ]

let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
  generate' ctx page
  |> Layout.render ctx