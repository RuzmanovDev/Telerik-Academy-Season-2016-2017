# Problem 2 – Parachute

You find yourself in a training for being the **best parachute jumper** in the world. At the beginning of the training you need to understand how **gravity** and **wind** work. You are given all the data from previous jumps of your colleagues. Your task is to determine how the **jumper** will **finish** his jump and **where** he will **land** exactly, based on the gravity and wind parameters.

You are given an **array of strings**. The **jumper** can be **anywhere** in the array and is denoted by the **&quot;o&quot; symbol**. You need to determine the **movement** of the jumper in **iterations**. On each iteration the jumper moves **one line down** , pulled by **gravity**. Additionally, the jumper moves **sideways** by the **wind** on the **current** line.

- The **&quot;&gt;&quot; symbol** means the wind is moving the jumper **one position** to the **right**.
- The **&quot;&lt;&quot; symbol** means the wind is moving the jumper **one position** to the **left**.

The **total direction** of the wind on a single line may **stack** (e.g. &quot; **&gt;&gt;&gt;**&quot; moves the jumper 3 positions to the right; &quot; **&gt;&lt;&lt;**&quot; moves the jumper 1 position to the left).

See examples to better understand the motion of the jumper.

The jumper can move only through **air** (the **&quot;-&quot; symbol** ). When the jumper hits the **ground** , **water** or a **cliff** , the jump is **finished** and you need to **print the outcome** of the jump.

### Input

The input will be passed to the first JavaScript function found in your code as **array of strings** , each containing a **symbol**. The **symbols** are **not separated** by anything. The input data will always be valid and in the format described.

### Output

The output consists of two lines. The first line holds a string: **&quot;[landing place] &quot;. There are 3 possible outcome messages:**

- If you have landed on the **ground** (&quot;\_&quot; symbol), you are well and alive: **&quot;Landed on the ground like a boss!&quot;**
- If you have landed in the **water** (&quot;~&quot; symbol), you have drowned: &quot; **Drowned in the water like a cat!&quot;**
- If you have landed on **a cliff** (&quot;/&quot;, &quot;\&quot; or &quot;|&quot; symbol), you have died: &quot; **Got smacked on the rock like a dog!**

The second line holds the **position** (the **row** and **col** )of your landing.

### Constraints

- The **row** and **col** of the matrix will be in the range **[0…10]**.
- The jumper will never fly off the map.
- Time limit: 0.3 sec. Memory limit: 16 MB.

### Examples

| **Input** | **Output** |   | **Input** | **Output** |
| --- | --- | --- | --- | --- |
| --o----------------------&gt;------------------------&gt;------------------------&gt;-----------------/\----------------------/--\----&gt;---------/\----/----\------------/--\--/------\--&lt;-------/----\/--------\-\------/----------------\-\\_\_\_\_/------------------ | Landed on the ground like a boss!9 5 |   | -------------o-&lt;&lt;----------------&gt;&gt;&gt;&gt;&gt;----------------------------&gt;-&lt;---&lt;--------&lt;&lt;&lt;&lt;&lt;-------/\--&lt;----------------&lt;--/-&lt;\----&gt;&gt;--------/\----/&lt;-&lt;-\------------/&lt;-\--/------\--&lt;-------/----\/--------\-\------/--------------&lt;-\-\\_\_\_~/------&lt;----------- | Drowned in the water like a cat!9 5 |