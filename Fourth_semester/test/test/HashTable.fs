module HashTable

type HashTable(hashFunc) =
    let hashTable = Array.init 101 (fun index -> List.empty)
    
    member this.Add x =
        let i = (hashFunc x) % 101
        if this.Contains(x) then
            printfn "%A" "this item already exists in the hash table"
        else
            hashTable.[i] <- List.Cons (x, hashTable.[i])

    member this.Contains x =
        let i = hashFunc x
        List.contains x hashTable.[i]
    
    member this.Remove x =
        let i = hashFunc x
        hashTable.[i] <- List.filter (fun elem -> x <> elem) hashTable.[i]

    member this.Print () =
        printfn "%A" "Hash table:"
        Seq.iteri (fun i elem -> printfn "%A" ("List number " + i.ToString() + ":")
                                 List.iter (fun x -> printf "%s" x) elem) hashTable