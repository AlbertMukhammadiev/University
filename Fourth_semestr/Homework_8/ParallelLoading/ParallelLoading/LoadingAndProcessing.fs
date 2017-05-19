module LoadingAndProcessing

open System.Net
open System.IO
open System.Threading
open System.Text.RegularExpressions

let references (url:string) =
    let request = WebRequest.Create(url)
    let response = request.GetResponse()
    let stream = response.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()    
    let matches = Regex.Matches(html, "(http:\/\/\S+)")
    let rec ls i acc =
        if i = 0 then
            acc
        else
            let str = (matches.Item i).ToString()
            let href = str.Remove <| str.IndexOf '\"'
            ls (i - 1) (href :: acc)
    
    ls (matches.Count - 1) []    

let fetchAsync url =
    async {
        do printfn "Creating request for %s..." url
        let request = WebRequest.Create(url)
        use! response = request.AsyncGetResponse()
        do printfn "Getting response stream for %s..." url
        use stream = response.GetResponseStream()
        do printfn "Reading response for %s..." url
        use reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        do printfn "Read %d characters for %s..." html.Length url
    }

let fetchAsync2 (url:string) =
    async {
        //do printfn "Creating request for %s..." url
        let request = WebRequest.Create(url)
        use! response = request.AsyncGetResponse()
        //do printfn "Getting response stream for %s..." url
        use stream = response.GetResponseStream()
        //do printfn "Reading response for %s..." url
        use reader = new StreamReader(stream)
        let html = reader.ReadToEnd()
        return html.Length
    }

let func url =
    let load (urls:list<string>) =
        let a = Seq.init urls.Length (fun i -> fetchAsync <| urls.Item i)
        ignore << Async.RunSynchronously << Async.Parallel <| a

    load <| references url

[<EntryPoint>]
let main (string) =
    func "https://translate.google.com"
    0