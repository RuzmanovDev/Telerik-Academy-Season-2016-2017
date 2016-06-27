function solve(args) {
    var x = +args[0],
        y=+args[1],
        insideCircle,
        insideRectangle;

     insideCircle = (x - 1) * (x - 1) + (y - 1) * (y - 1) <= 1.5 * 1.5 ? true : false;
     insideRectangle = (x >= -1 && x <= 5) && (y >= -1 && y <= 1) ? true : false;

    if (insideCircle && insideRectangle)
    {
        return 'inside circle inside rectangle'
    }
    else if (!insideCircle && insideRectangle)
    {
        return 'outside circle inside rectangle'
    }
    else if (insideCircle && !insideRectangle)
    {
        return 'inside circle outside rectangle'
    }
    else
    {
        return 'outside circle outside rectangle'
    }
}