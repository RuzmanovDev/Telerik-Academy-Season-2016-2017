function createCalendar(selector, events) {
    var container = document.querySelector(selector),
        divTemplate = document.createElement("div"),
        weekDivTemplate = document.createElement("div"),
        h5Template = document.createElement("h5"),
        paragraphTemplate = document.createElement("span");

    setDaySyles(divTemplate);
    setHeaderStyles(h5Template);
    setParagraphStyles(paragraphTemplate);
    function generateEvent(events) {
        var eventsWithIndex = [];
        for (var i = 0; i < events.length; i += 1) {
            var currentDay = +events[i].date;
            eventsWithIndex[currentDay] = events[i];
        }

        return eventsWithIndex;
    }
    var days = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
    var MONTH = "June 2014";
    var eventsWithIndex = generateEvent(events);
    var dayOfWeek = 1;

    for (var week = 0; week < 5; week += 1) {
        var weekDiv = weekDivTemplate.cloneNode(true);
        for (var day = 0; day < 7; day += 1) {
            if (dayOfWeek === 31) {
                break;
            }
            var dayDiv = divTemplate.cloneNode(true);
            var header = h5Template.cloneNode(true);
            header.textContent = days[day] + " " + dayOfWeek + " " + MONTH;
            dayOfWeek += 1;
            var content = generateContent(dayOfWeek);
            dayDiv.appendChild(header);
            if (content) {
                dayDiv.appendChild(content);
            }
            weekDiv.appendChild(dayDiv);

        }
        container.appendChild(weekDiv);
    }
    atachEvents();

    function generateContent(dayOfWeek) {
        var content = paragraphTemplate.cloneNode(true);
        var currentData = eventsWithIndex[dayOfWeek + 1];
        if (currentData) {
            content.innerHTML = currentData.title + " " + currentData.date + " " + currentData.hour + " " + currentData.duration;
        }
        return content;
    }
    function setDaySyles(day) {
        day.classList.add("day-container");

        day.style.display = "inline-block";
        day.style.border = "1px solid black";
        day.style.width = "150px";
        day.style.height = "150px";
    }
    function setHeaderStyles(header) {
        header.style.borderBottom = "1px solid black";
        header.style.backgroundColor = "lightgrey";
        header.style.textAlign = "center";
        header.style.marginTop = "0";
        header.style.marginBottom = "0";
        header.style.paddingTop = "0";
    }

    function setParagraphStyles(paragraph) {
        paragraph.style.float = "left";
    }

    function atachEvents() {
        container.addEventListener("click", function (ev) {
            var that = this;
            var target = ev.target;
            if (target.classList.contains("day-container")) {
                if (target.getElementbyTagName("h5")) {
                    
                }

            }
        }, false);
    }

}