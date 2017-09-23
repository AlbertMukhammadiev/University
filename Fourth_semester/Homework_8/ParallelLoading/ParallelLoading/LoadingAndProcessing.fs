module LoadingAndProcessing

open System.Net
open System.IO
open System.Text.RegularExpressions

let fetchPage (url:string) =
    async {
        let request = WebRequest.Create(url)
        use! response = request.AsyncGetResponse()
        use stream = response.GetResponseStream()
        use reader = new StreamReader(stream)
        return reader.ReadToEnd()
    }

let fetchLength (url:string) =
    async {
        let! html = fetchPage url
        return url, html.Length
    }

let references (url:string) =
    let html = Async.RunSynchronously <| fetchPage url
    let matches = Regex.Matches(html, "(http:\/\/\S+)")
    let rec ls i acc =
        if i = 0 then
            acc
        else
            let str = (matches.Item i).ToString()
            let href = str.Remove <| str.IndexOf '\"'
            ls (i - 1) (href :: acc)
    ls (matches.Count - 1) []    

let getLengths url =
    let load (urls:list<string>) =
        let seq = Seq.init urls.Length (fun i -> fetchLength <| urls.Item i)
        printfn "%A" << Async.RunSynchronously << Async.Parallel <| seq
    load <| references url