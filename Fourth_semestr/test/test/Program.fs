module program

open PrintSquare
open Sequence
open HashTable

[<EntryPoint>]
let main argv = 
    let table1 = new HashTable(String.length)
    table1.Add("Jacob")
    table1.Add("William")
    table1.Add("Christopher")
    table1.Add("Ryan")
    table1.Add("David")
    table1.Add("Alexander")
    table1.Add("James")
    table1.Add("Jonathan")
    table1.Add("Jose")
    table1.Add("Kevin")
    table1.Add("Luke")
    table1.Add("Cameron")
    table1.Print()
    0 // возвращение целочисленного кода выхода
