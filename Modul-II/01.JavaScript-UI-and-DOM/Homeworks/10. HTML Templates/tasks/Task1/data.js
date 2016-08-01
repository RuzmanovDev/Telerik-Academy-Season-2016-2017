window.onload =
    function solve() {
        return function task1() {
            var data = {
                headers: ['Vendor', 'Model', 'OS'],
                items: [{
                    col1: 'Nokia',
                    col2: 'Lumia 920',
                    col3: 'Windows Phone'
                }, {
                    col1: 'LG',
                    col2: 'Nexus 5',
                    col3: 'Android'
                }, {
                    col1: 'Apple',
                    col2: 'iPhone 6',
                    col3: 'iOS'
                }]
            };

            var phonesTemplateHTML = document.getElementById('phonesTemplate').innerHTML;
            var phonesTemplate = Handlebars.compile(phonesTemplateHTML);
            // console.log(phonesTemplate(data));

            var root = document.getElementById('root').innerHTML = phonesTemplate(data)
        };
    };