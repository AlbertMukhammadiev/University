module Sequence

let sequence =
    let partSeq k = Seq.init k (fun x -> k)
    Seq.concat <| Seq.initInfinite (fun x -> partSeq x)

let getSeq n sequence = Seq.take n sequence

