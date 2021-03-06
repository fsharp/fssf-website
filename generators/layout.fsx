﻿#r "../_lib/Fornax.Core.dll"
#if !FORNAX
#load "../loaders/postloader.fsx"
#load "../loaders/pageloader.fsx"
#load "../loaders/globalloader.fsx"
#endif

open Html

let injectWebsocketCode (webpage:string) =
    let websocketScript =
        """
        <script type="text/javascript">
          var wsUri = "ws://localhost:8080/websocket";
      function init()
      {
        websocket = new WebSocket(wsUri);
        websocket.onclose = function(evt) { onClose(evt) };
      }
      function onClose(evt)
      {
        console.log('closing');
        websocket.close();
        document.location.reload();
      }
      window.addEventListener("load", init, false);
      </script>
        """
    let head = "<head>"
    let index = webpage.IndexOf head
    webpage.Insert ( (index + head.Length + 1),websocketScript)

let layout (ctx : SiteContents) active bodyCnt =
    let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
    let ttl =
      siteInfo
      |> Option.map (fun si -> sprintf "%s: %s" si.title active)
      |> Option.defaultValue ""

    html [] [
        head [] [
            meta [CharSet "utf-8"]
            meta [HttpEquiv "Content-Type"; Content "text/html; charset=utf-8"]
            meta [Name "viewport"; Content "width=1510"]
            meta [Name "format-detection"; Content "telephone=no"]
            title [] [!! ttl]
            link [Rel "icon"; Type "image/png"; Sizes "32x32"; Href "images/favicon.png"]
            link [Rel "stylesheet"; Type "text/css"; Href "https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&display=swap"]
            link [Rel "stylesheet"; Type "text/css"; Href "css/fontawesome.min.css"]            
            link [Rel "stylesheet"; Type "text/css"; Href "css/solid.min.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "css/brands.min.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "css/style.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick-theme.css"]
        ]
        body [] [
          div [Class "wrapper"] [
            header [] [
              div [Class "container"] [
                div [Class "header-top"] [
                  div [Class "header-lft"] [
                    h5 [] [!! "Already a fan of F#?"]
                    h6 [] [!! "Join the community, membership is free."]
                  ]
                  div [Class "header-rgt"] [
                    ul [] [
                      li [] [ a [Href "#"] [!! "REGISTER"] ]
                      li [] [ a [Href "#"] [!! "LOGIN"] ]
                    ]
                  ]
                  div [Class "clear"] []
                ]
                div [Class "header-main"] [
                  nav [] [
                    ul [] [
                      li [] [ a [Href "about.html"] [!! "ABOUT F#"] ]
                      li [] [
                        a [Href "docs.html"] [!! "DOCS"]
                        div [ Class "header-btm" ] [
                          ul [] [
                            li [ Class "connect" ] [ a [Href "#"] [!! "API"] ]
                            li [] [ a [Href "#"; Class "login"] [!! "LEARN"] ]
                            li [] [ a [Href "#"] [!! "GUIDELINE"] ]
                            li [] [ a [Href "#"] [!! "REFERENCE"] ]
                            li [] [ a [Href "#"] [!! "CHEAT SHEET"] ]
                          ]
                        ]
                      ]
                      li [] [ a [Href "https://try.fsharp.org"] [!! "TRY ONLINE"] ]
                      li [] [ a [Href "install.html"] [!! "INSTALL"] ]
                      li [] [ a [Href "community.html"] [!! "COMMUNITY"] ]
                      li [] [ a [Href "foundation.html"] [!! "FOUNDATION"] ]
                    ]
                  ]
                ]
                div [Class "container"] [
                  div [Class "social-icon"] [
                    ul [] [
                      li [Class "facebook"] [a [Href "#"] [i [Class "fab fa-facebook fa-3x"] []]]
                      li [Class "twitter"] [a [Href "#"] [i [Class "fab fa-twitter fa-3x"] []]]
                      li [Class "teddy"] [a [Href "#"] [i [Class "fab fa-github fa-3x"] []]]
                      li [] [ input [Type "text"; Name "lastname"; Placeholder "Search"] ]
                    ]
                  ]
                ]
              ]
            ]
            // Pages pass their content here
            div [] bodyCnt
            footer [] [
              div [Class "container"] [
                div [Class "footer-in"] [
                  div [Class "ftr-lft"] [
                    div [Class "ftr-txt"] [
                      h4 [] [!!"become a member"]
                      ul [] [
                        li [] [ input [ Type "text"; Name "lastname"; Placeholder "Email Address" ] ]
                        li [] [ button [] [!!"JOIN"] ]
                      ]
                      a [Href "#"] [!!"Learn more about F# memberships"]
                    ]
                    div [Class "spanish"] [
                      ul [] [
                        li [] [ a [Href "#"; Class "active"] [!!"English"] ]
                        li [] [ a [Href "#"] [!!"Spanish"] ]
                        li [] [ a [Href "#"] [!!"Japanese"] ]
                        li [] [ a [Href "#"] [!!"Russian"] ]
                        li [] [ a [Href "#"] [!!"Czech"] ]
                        li [] [ a [Href "#"] [!!"French"] ]
                        li [] [ a [Href "#"] [!!"Portuguese"] ]
                      ]
                    ]
                  ]
                  div [Class "ftr-rgt"] [
                    div [Class "ftr-cont"] [
                      p [] [ !!"Copyright © 2012-2021 F# Software Foundation and individual contributors. Maintained by F# Software Foundation and the F# community on GitHub." ]
                    ]
                  ]
                  div [Class "clear"] []
                ]
              ]
            ]
          ]
          script [Src "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"] []
          script [Src "//cdn.jsdelivr.net/npm/slick-carousel@1.8.1/slick/slick.min.js"] []
          script [] [
            !!"""
            $(document).ready(function(){
               if ($(this).scrollTop()) {
                   $('.back-to-top').fadeIn();
               } else {
                   $('.back-to-top').fadeOut();
               }
            });
            $('.scrollToTop').click(function(){
                            $('html, body').animate({scrollTop : 0},1500);
                            return false;
                        });
            """
          ]
          script [] [
            !!"""
          $(document).ready(function(e){
            $('.slider').slick({
				        autoplay: true,
				        autoplaySpeed: 3000,
				        infinite: true,
				        speed: 500,
				        fade: false,
				        arrows:true,
				        dots:false,
				        cssEase: 'linear'
              })
            })
            """
          ]
        ]
    ]

let render (ctx : SiteContents) cnt =
  let disableLiveRefresh = ctx.TryGetValue<Postloader.PostConfig> () |> Option.map (fun n -> n.disableLiveRefresh) |> Option.defaultValue false
  cnt
  |> HtmlElement.ToString
  |> fun n -> if disableLiveRefresh then n else injectWebsocketCode n

let published (post: Postloader.Post) =
    post.published
    |> Option.defaultValue System.DateTime.Now
    |> fun n -> n.ToString("yyyy-MM-dd")

let postLayout (useSummary: bool) (post: Postloader.Post) =
    div [Class "card article"] [
        div [Class "card-content"] [
            div [Class "media-content has-text-centered"] [
                p [Class "title article-title"; ] [ a [Href post.link] [!! post.title]]
                p [Class "subtitle is-6 article-subtitle"] [
                a [Href "#"] [!! (defaultArg post.author "")]
                !! (sprintf "on %s" (published post))
                ]
            ]
            div [Class "content article-body"] [
                !! (if useSummary then post.summary else post.content)

            ]
        ]
    ]
