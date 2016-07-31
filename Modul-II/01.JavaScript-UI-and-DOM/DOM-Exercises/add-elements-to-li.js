(function () {
    function addElements() {
        var $textInput = $("#text-input"),
            text = $textInput.val(),
            $ul = $("#message-list"),
            $li = $liTemplate.clone(true),
            $check = $checkBoxTemplate.clone(true);
        $li.text(text);
        $li.append($check);
        $ul.append($li);
        // clear the text box
        $textInput.val("");
    }

    function deleteElements() {
        var $selected = $('input[name="options"]:checked');
        console.log($selected);

        $selected.parent('.list-item').remove();
    }

    var $button = $("#send-button"),
        $liTemplate = $("<li />").addClass('list-item'),
        $checkBoxTemplate = $("<input />")
            .attr({
                name: 'options'
                , value: ''
                , type: 'checkbox'
            }),
        $deleteButton = $("#delete-button");


    $button.on("click", addElements);
    $deleteButton.on("click", deleteElements);
}());