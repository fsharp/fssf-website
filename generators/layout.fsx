#r "../_lib/Fornax.Core.dll"
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
      |> Option.map (fun si -> si.title)
      |> Option.defaultValue ""

    html [] [
        head [] [
            meta [HttpEquiv "Content-Type"; Content "text/html; charset=utf-8"]
            meta [Name "viewport"; Content "width=1510"]
            meta [Name "format-detection"; Content "telephone=no"]
            title [] [!! ttl]
            link [Rel "icon"; Type "image/png"; Sizes "32x32"; Href "images/favicon.png"]
            link [Rel "stylesheet"; Type "text/css"; Href "https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i,800,800i&display=swap"]
            link [Rel "stylesheet"; Type "text/css"; Href "css/font-awesome.min.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "css/style.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "https://kenwheeler.github.io/slick/slick/slick.css"]
            link [Rel "stylesheet"; Type "text/css"; Href "https://kenwheeler.github.io/slick/slick/slick-theme.css"]
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
                      li [] [ a [Href "#"] [!! "ABOUT F#"] ]
                      li [] [
                        a [Href "#"] [!! "DOCS"]
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
                      li [] [ a [Href "#"] [!! "TRY ONLINE"] ]
                      li [] [ a [Href "#"] [!! "INSTALL"] ]
                      li [] [ a [Href "#"] [!! "COMMUNITY"] ]
                      li [] [ a [Href "#"] [!! "FOUNDATION"] ]
                    ]
                  ]
                ]
                div [Class "container"] [
                  div [Class "social-icon"] [
                    ul [] [
                      li [Class "facebook"] [a [Href "#"] [i [Class "fa fa-facebook"] []]]
                      li [Class "twitter"] [a [Href "#"] [i [Class "fa fa-twitter"] []]]
                      li [Class "teddy"] [a [Href "#"] [i [Class "fa fa-github"] []]]
                      li [] [ input [Type "text"; Name "lastname"; Placeholder "Search"] ]
                    ]
                  ]
                ]
              ]
            ]
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
                a [Href "#"; Class "scrollToTop"] [i [Class "fa fa-angle-up"] []]
              ]
            ]
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
                      p [] [ !!"Copyright © 2012-2018 F# Software Foundation and individual contributors. Maintained by F# Software Foundation and the F# community on GitHub." ]
                    ]
                  ]
                  div [Class "clear"] []
                ]
              ]
            ]
          ]
          script [Src "https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"] []
          script [Src "https://kenwheeler.github.io/slick/slick/slick.js"] []
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
