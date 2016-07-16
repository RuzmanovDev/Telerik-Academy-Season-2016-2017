# Problem 1 – The Teteven Trip

New Year&#39;s Eve was approaching so you and your friends have decided to celebrate it in a hut in the Teteven Balkan. In order to do that you had to go to Teteven first but you need to know how much liters of fuel you would need. Your task is to calculate the fuel consumption of your vehicles.

You will receive as input data an **array** of **n** elements. Each **element** will consist of a **string** in the format **&quot;[car model] [fuel type] [route number] [luggage weight]&quot;**. For example **valid input** string is **&quot;BMW diesel 1 54.5&quot;** – the car model is **BMW** , the fuel type is **diesel** , the route number is **1** and the luggage weight is **54.5** kg.

The **base fuel consumption** is **10L per 100km**. There are **3 fuel types** – **&quot;gas&quot;** , **&quot;petrol&quot;** and **&quot;diesel&quot;**. Each type has a correction coefficient **c**. For **gas c = 1.2** , for **petrol c = 1** , for **diesel c = 0.8**. For example if the fuel type is gas the fuel consumption is 1.2\*(10L) = 12L per 100km. For **every kg of luggage** you need to add **0.01L extra fuel consumption**. There are **2 routes to Teteven** – **route &quot;1&quot;** and **route &quot;2&quot;**. **Route &quot;1&quot;** is long **110km** (100km normal road and **10km snowy road** ). **Route &quot;2&quot;** is long **95km** (65km normal road and **30km snowy road** ). The **total fuel consumption** is calculated by multiplying the base fuel consumption and the **total**** route distance **. Then you should add the route&#39;s** snow distance **multiplied by** 30%** of the total fuel consumption. See the example below for further details.

When you calculate the fuel consumption you must **first** consider the **fuel type** and then **add the extra fuel consumption** needed for the **luggage weight**. In the end you must consider **if the road is snowy** or not. Then you should **round** the fuel liters **to an integer value**.

### Input

The input data will be received as **an array of**** n elements, **each containing a** string **. The** string contains 4 arguments **– the** car model **, the** fuel type **, the** route number **and the** luggage weight **. The** arguments **of the input string will always be** separated by exactly 1 space **. Every** argument **of the string will always** consist of only 1 word.** The input data will always be valid and in the format described. There is no need to check it explicitly.

### Output

The output consists of **n lines**. Each line should hold the **car model** , the **fuel type** , the **route number** and the **quantity of fuel needed in liters** (all space-separated). The **quantity of fuel** is **rounded to an integer number**. For example **24.49** rounds to **24** and **24.50** rounds to **25**.

### Constraints

- The **luggage weight** will be a **floating-point number** no greater than **500**.
- Time limit: 0.3 sec. Memory limit: 16 MB.

### Examples

| **Input** | **Output** | **Comment** |
| --- | --- | --- |
| [&#39;BMW petrol 1 320.5&#39;,&#39;Golf petrol 2 150.75&#39;,&#39;Lada gas 1 202&#39;,&#39;Mercedes diesel 2 312.54&#39;] | BMW petrol 1 15Golf petrol 2 12Lada gas 1 16Mercedes diesel 2 12 | We take &quot;BMW petrol 1 320.5&quot;. We have a base consumption of 10l per 100km. For petrol c = 1, so the consumption stays 10l per 100km. Extra fuel for luggage is 320.5\*0.01l = 3.205l. So now the base fuel consumption is 10 + 3.205 = 13.205l per 100km. Route 1 has 110 km in total. The total consumption is calculated by 110km\*(13.205l/100km) = 14.5255l. The extra snow consumption is 0.3\*13.205 = 3.962l per 100km. Now we add 10km\*(3.962l/100km) = 0.3962l. The total amount is now 0.3962 + 14.5255 = 14.9217l. When rounded the total fuel consumption is 15l. |