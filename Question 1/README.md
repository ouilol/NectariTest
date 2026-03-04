# Question 1 — .NET / OOP

You are building a tiny ordering tool for a table‑tennis shop.

**Task**
- Complete the code in `Question_1.cs`.
- Add three concrete item classes: `Table`, `Paddle`, and `Balls`.
- Use inheritance and abstraction properly (`Item` is abstract).
- Each item must have a price and weight.
- Implement `getFullPrice()` to return the price including a 20% tax.
- Add one table, two paddles, and three packs of balls to `items`.
- Print the item name and full price for each entry.

**Deliverables**
- Updated `Question_1.cs` with working, readable code.
- A short note explaining your class design choices.

****************************************************************************************

On déclare les trois classes avec un constructeur pour initialiser le poids et le prix initiaux.
Chaque classe hérite de Item pour définir le prix et le poids, qui proviennent de leur héritage.
J'ai ajouté un attribut Qt pour pouvoir déclarer la quantité de chaque classe dont nous avons besoin. 
Par la suite, on calcule le total de chaque classe avec la fonction abstraite qui est générée dans chaque classe.
Pour finir, on écrit à l'écran pour chaque élément dans items leur nom et le coût de chacun.