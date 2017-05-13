module HashTableTests

open HashTable
open NUnit.Framework
open FsUnit
open FsCheck

type Tests() =
    let table = new HashTable(String.length)
    do
        table.Add("Jacob")
        table.Add("William")
        table.Add("Christopher")
        table.Add("Ryan")
        table.Add("David")
        table.Add("Alexander")
        table.Add("James")
        table.Add("Jonathan")
        table.Add("Jose")
        table.Add("Kevin")
        table.Add("Luke")
        table.Add("Cameron")

    [<Test>]
    member this.``test of Add`` () =
        let word = "Lee"
        table.Add(word)
        table.Contains(word) |> should equal true

    [<Test>]
    member this.``test of Contains`` () =
        table.Contains("Jose") |> should equal true
        table.Contains("Ivan") |> should equal false
        table.Contains("Luke") |> should equal true

    [<Test>]
    member this.``test of Remove`` () =
        table.Add("Cain");
        table.Remove("Cain")
        table.Contains("Cain") |> should equal false