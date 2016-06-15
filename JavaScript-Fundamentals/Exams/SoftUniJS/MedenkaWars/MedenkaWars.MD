# Problem 1 – Medenka Wars

In a galaxy far-far away… The Dark Medenka Side and The Light Medenka Side are in a ruthless war. Their leaders The Dark Medenka Lord Naskor and The White Medenka Lord Vitkor are fighting mercilessly, and the medenkas are their only weapons.

You will be receiving several lines containing medenka data in the following formats – &quot;2 white medenkas&quot;, &quot;1 dark medenkas&quot;... The **amount** of medenkas, specify the **damage** every lord deals to the other. Because Naskor and Vitkor are both great lords, they are immortal, so the winner will be decided by the **most**** damage dealt**.

**1 medenka = 60 damage.**

If the input is &quot; **white** medenkas&quot;, Vitkor attacks, if it&#39;s &quot; **dark** medenkas&quot;, Naskor attacks. The great lords also have special abilities. If Naskor makes **5**** consecutive normal **attacks with the** same damage **, the 5-th attack&#39;s damage will be** multiplied **by** 4.5 **. This counts as a** normal **attack. If Vitkor makes** 2 ****consecutive**** normal **attacks with the** same damage **, the** second **attack becomes** special **and deals** x2.75 damage**.

When you receive all the input you must find the winner. The winner is determined by the **most damage dealt**. It is safe to assume, that there will be no stalemates.

### Input

- The input data is passed to the first JavaScript function found in your code as an **array of strings**.
- You will receive several lines in format &quot;# white medenkas&quot; or &quot;# dark medenkas&quot; where &#39;#&#39; is an integer number.
- When you read all received lines and calculate the damage dealt by both lords you may print the winner.

### Output

- The consists of three lines:
- &quot;Winner – {winner name}&quot;, where winner name is either Vitkor or Naskor.
- &quot;Damage – {damage dealt}&quot;, the damage that the winner dealt to the loser.

### Constraints

- The amount of input medenkas is in range [0, 100000].
- The amount of input lines you can receive is in range [0, 10000].
- The format will always be valid, there is no need to check it explicitly.
- May the medenka force be with you.
- Allowed time/memory: 100ms/16MB

### Examples

| **Input** | **Output** |
| --- | --- |
| 5 white medenkas5 dark medenkas4 white medenkas | Winner - VitkorDamage - 540 |



| **Input** | **Output** |
| --- | --- |
| 2 dark medenkas1 white medenkas2 dark medenkas2 dark medenkas15 white medenkas2 dark medenkas2 dark medenkas | Winner - NaskorDamage - 1020 |