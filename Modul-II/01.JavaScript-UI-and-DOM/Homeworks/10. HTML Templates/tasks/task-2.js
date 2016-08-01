/* globals $ */

function solve() {

  return function (selector) {
    /* insert the template here as a string
        example:
        var template =
          '<ul>' +
            '{{#students}}' +
            '<li>' +
              '{{name}}' +
            '</li>' +
            '{{/students}}' +
          '</ul>';
    */

    var template = '<div class="container">' +
      '<h1>Animals</h1>' + 
    '<ul class="animals-list">' +
      '{{#animals}}' +
      '<li>' +
      '{{#if url}}' +
      '<a href="{{url}}">See a {{name}}</a>' +
      '{{else}}' +
      '<a href="http://cdn.playbuzz.com/cdn/3170bee8-985c-47bc-bbb5-2bcb41e85fe9/d8aa4750-deef-44ac-83a1-f2b5e6ee029a.jpg">No link for {{name}}, here is Batman!</a>' +
      '{{/if}}' +
      '</li>' +
      '{{/animals}}' +
      '</ul>' +
      '</div>';

    $(selector).html(template);
  };
}

module.exports = solve;