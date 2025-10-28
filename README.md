# ⚔️ # CodeQuest: L’aventura del programador/a de videojocs

# 🧙‍♂️ Projecte: El Camí del Mag Aprenent

## Chapter 1. El camí del mag aprenent 🧙‍♀️

Has estat admès a l’Acadèmia d’Arcanistes, però abans de començar necessites entrenar el teu poder màgic.

Demana el **nom del mag** i defineix el seu **nivell inicial a 1**.  
Cada dia d’entrenament (**5 dies**), el mag dedica una quantitat d’hores de meditació i obté una **quantitat aleatòria de poder** entre `1` i `10` punts.

Cada dia, mostra un missatge de la seva evolució dia a dia, amb un format similar a:

Dia 3 → Azrael, ja has meditat 10 hores i el teu poder ara és de 27 punts!

Al final, mostra el **nivell final de poder**. Segons el total:

| Rang de poder | Missatge | Nivell obtingut |
|----------------|-----------|----------------|
| ≤ 20 | “Encara confons la vareta amb una cullera.” | Zyn el Buguejat |
| < 30 | “Ets un Invocador de Brises Màgiques.” | Arka Nullpointer |
| > 35 i < 40 | “Uau! Pots invocar dracs sense cremar el laboratori!” | Elarion de les Brases |
| ≥ 47 | “Has assolit el rang de Mestre dels Arcans!” | ITB-Wizard el Gris |

> 🔍 **TIP:** Investiga com crear nombres aleatoris amb la classe `Random`.

---

## Chapter 2. El calabós del Drac RAMón el Poderós 🐉

El teu mag ha de demostrar el seu entrenament i ha d’entrar al **Calabós del Drac RAMón el Poderós**, on cada porta està protegida per un **codi d’accés digital**.

- Hi ha **3 portes**.  
- Cada una té un **codi aleatori entre 1 i 5**.  
- Tens **3 intents per porta**.

Regles del joc:

- ❌ Si falles una porta, el joc acaba amb el missatge: El drac ha detectat la teva presència i t’ha expulsat del servidor!
- ✅ Si encertes, apareix el missatge: El drac et respecta. Has desbloquejat el següent nivell!
- 🏆 Si arribes a la **tercera porta** i l’obres amb èxit: Has desbloquejat el nivell final. Prepara’t per la batalla!

> 🔍 **TIP:** Pensa en **bucles imbricats** per resoldre aquest repte.

---

## Chapter 3. Lotejar el botí 💰

Has derrotat al drac i has trobat una mina plena de **bitcoins màgics!**

- Cada cop que mines, obtens una quantitat **aleatòria entre 5 i 50 bits**, o potser **res**.
- Només pots fer **5 excavacions**.
- Mostra el resultat de cada excavació.

A cada intent d’excavació pot haver-hi una **probabilitat de no trobar res**.  
Si això passa, mostra:

Avui no és el teu dia de sort, has trobat 0 bits.

Finalment:

- Si el total **> 200 bits**: Has desbloquejat la GPU d’or! Els teus encanteris van ara a 120 FPS!
- Si el total **≤ 200 bits**: La teva targeta màgia encara és integrada. Toca derrotar a un altre drac!

---

> ✨ *Recorda: cada mag comença com a aprenent, però fins i tot el millor arcanista va començar amb un bucle `for`...*



