/* globals module */
function solve() {
    return function (selector, items) {
      var container = document.querySelector(selector);

      console.log(container);

      var leftBox = document.createElement('div');
      var rightBox = document.createElement('div');
      container.appendChild(leftBox);
      container.appendChild(rightBox);
      //left

      leftBox.style.display = "inline-block";
      leftBox.style.float = "left";
      leftBox.style.width = "400px";     
      leftBox.classList.add('image-preview');

      var leftBoxHeader = document.createElement('h1');
      leftBoxHeader.innerText = items[0].title;
      leftBoxHeader.style.textAlign="center";
      leftBox.appendChild(leftBoxHeader);
    

      var leftBoxImageCointaner = document.createElement('img');
      leftBoxImageCointaner.style.width = "400px";
      leftBoxImageCointaner.src=items[0].url;
      leftBox.appendChild(leftBoxImageCointaner);

      //right
      //search
      rightBox.style.width = "200px";
      rightBox.style.display = "inline-block";
      rightBox.style.float = "left";
      
      var searchBox = document.createElement('div');
      var searchBoxHeading = document.createElement('p');
      searchBoxHeading.innerText = "Filter";
      searchBoxHeading.style.textAlign = 'center';
      var searchBoxInput = document.createElement('input');
      searchBoxInput.style.width = "80px";
      searchBoxInput.style.margin = "auto";
      searchBox.addEventListener('keyup',function(ev){
          var text = ev.target.value;
          var elements = menuContainer.children;
          for(var i =0;i<elements.length;i+=1){
              var header = elements[i].firstElementChild.innerText;
              if(header.toLowerCase().indexOf(text.toLowerCase())>=0){
                  elements[i].style.display="block";
              }
              else{
                  elements[i].style.display="none";
              }
          }
      },false);

      searchBox.appendChild(searchBoxHeading);
      searchBox.appendChild(searchBoxInput);

      rightBox.appendChild(searchBox);

      // image-containers

      var menuContainer = document.createElement('div');
      menuContainer.style.overflow = "scroll";
      menuContainer.style.height = "300px";
      rightBox.appendChild(menuContainer);


      for(var i = 0 , len=items.length; i<len; i+=1){
          var imageContainer = document.createElement('div');
          imageContainer.classList.add('image-containers');
          imageContainer.addEventListener('mouseover',function(){
                this.style.backgroundColor = "grey";
          },false);
          imageContainer.addEventListener('mouseout',function(){
                this.style.backgroundColor = "white";
          },false);

          var imageContainerHeader = document.createElement('h3');
          imageContainerHeader.innerText=items[i].title;
          imageContainerHeader.style.marginBottom = "0px";
          imageContainerHeader.style.textAlign="center";

          var imageContainerImage = document.createElement('img');
          imageContainerImage.style.width="80%";
          imageContainerImage.style.paddingTop=0;
          imageContainerImage.src=items[i].url;
          imageContainerImage.style.paddingLeft = "10%";

          imageContainer.appendChild(imageContainerHeader);
          imageContainer.appendChild(imageContainerImage);

          menuContainer.appendChild(imageContainer);
        
      }

      menuContainer.addEventListener('click',function(ev){
          var target = ev.target;
          console.log(target);
          if(target.tagName === "IMG"){
              var clickedImageSrc = target.src;
              console.log(clickedImageSrc);
              var clickedImageTitle = target.previousElementSibling.innerText;
              console.log(clickedImageTitle);
              leftBoxHeader.innerText = clickedImageTitle;
              leftBoxImageCointaner.src = clickedImageSrc;
          }
      },false);
    };
}

module.exports = solve;