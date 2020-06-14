#r "../_lib/Fornax.Core.dll"

type SiteInfo = {
    title: string
    description: string
}

let loader (projectRoot: string) (siteContent: SiteContents) =
    siteContent.Add({title = "F# Software Foundation"; description = "The Official Website of the F# Software Foundation, whose mission is to grow, support, and educate a diverse community around the F# programming language ecosystem."})

    siteContent
