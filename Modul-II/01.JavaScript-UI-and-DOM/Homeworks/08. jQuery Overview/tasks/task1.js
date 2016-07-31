/* globals $ */

/*

 Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:
 * The UL must have a class `items-list`
 * Each of the LIs must:
 * have a class `list-item`
 * content "List item #INDEX"
 * The indices are zero-based
 * If the provided selector does not selects anything, do nothing
 * Throws if
 * COUNT is a `Number`, but is less than 1
 * COUNT is **missing**, or **not convertible** to `Number`
 * _Example:_
 * Valid COUNT values:
 * 1, 2, 3, '1', '4', '1123'
 * Invalid COUNT values:
 * '123px' 'John', {}, []
 */

function solve() {
    return function solve(selector, count) {
        var numberOfItems;

        if (!count || !Number(+count)) {
            throw Error();
        }

        numberOfItems = +count;

        if (numberOfItems <= 1) {
            throw  Error();
        }

        var $element = $(selector);

        var $ul = $("<ul />");
        $ul.addClass("items-list");
        var $liTemplate = $('<li />');
        $liTemplate.addClass('list-item');

        if (!$element.length) {
            $element.append($ul);
            return
        }

        for (var i = 0; i < numberOfItems; i++) {
            var $li = $liTemplate.clone(true);

            $li.text("List item #" + i);

            $ul.append($li);
        }

        $element.append($ul);
    }
}