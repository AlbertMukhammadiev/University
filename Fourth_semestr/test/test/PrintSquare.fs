module PrintSquare

let print n =
    let rec printTR n seq =
        let length = Seq.length seq
        if length = n then
            Seq.iter (fun x -> printf "%c" x) seq
            printfn ""
            printTR (n - 1) (seq)
        else if n = 1 then
            Seq.iter (fun x -> printf "%c" x) seq
            printfn ""
        else
            printf "%c" '*'
            Seq.iter (fun x -> printf "%c" ' ') <| Seq.take (length - 2) seq
            printfn "%c" '*'
            printTR (n - 1) (seq)    

    if n < 2 then printfn "%c" '*'
    else
        let seq n = Seq.init n (fun x -> '*')
        let stars = seq n
        printTR n stars 
