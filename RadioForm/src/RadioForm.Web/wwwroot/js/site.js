(function () {
    "use strict";

    const items = [
        {
            name: "Item 1",
            radios: [
                { img: "img/audience-868074_640.jpg", label: "Item 1, audience" },
                { img: "img/books-1245690_640.jpg", label: "Item 1, books" },
                { img: "img/chicago-690364_640.jpg", label: "Item 1, Chicago" }
            ]
        }, {
            name: "Item 2",
            radios: [
                { img: "img/girl-1246525_640.jpg", label: "Item 2, girl" },
                { img: "img/home-office-336378_640.jpg", label: "Item 2, home-office" },
                { img: "img/light-bulb-1246043_640.jpg", label: "Item 2, lightbulb" },
                { img: "img/microphone-1209816_640.jpg", label: "Item 2, microphone" }
            ]
        }, {
            name: "Item 3",
            radios: [
                { img: "img/office-1209640_640.jpg", label: "Item 3, office" },
                { img: "img/person-1245959_640.jpg", label: "Item 3, person" }
            ]
        }, {
            name: "Item 4",
            radios: [
                { img: "img/pier-569314_640.jpg", label: "Item 4, pier" },
                { img: "img/sparkler-677774_640.jpg", label: "Item 4, sparkler" },
                { img: "img/summerfield-336672_640.jpg", label: "Item 4, summerfield" }
            ]
        }, {
            name: "Item 5",
            radios: [
                { img: "img/taxi-cab-381233_640.jpg", label: "Item 5, taxicab" },
                { img: "img/tie-690084_640.jpg", label: "Item 5, tie" },
                { img: "img/typewriter-801921_640.jpg", label: "Item 5, typewriter" },
                { img: "img/urban-438393_640.jpg", label: "Item 5, urban" }
            ]
        }, {
            name: "Item 6",
            radios: [
                { img: "img/workplace-1245776_640.jpg", label: "Item 6, workplace" },
                { img: "img/writing-1149962_640.jpg", label: "Item 6, writing" },
                { img: "img/pastel-4829602_640.jpg", label: "Item 6, pastel" }
            ]
        }, {
            name: "Item 7",
            radios: [
                { img: "img/writing-828911_640.jpg", label: "Item 7, writing" },
                { img: "img/young-girl-1149701_640.jpg", label: "Item 7, young girl" },
                { img: "img/flowers-4836548_640.jpg", label: "Item 7, flowers" }
            ]
        }, {
            name: "Item 8",
            radios: [
                { img: "img/barbary-ape-4854414_640.jpg", label: "Item 8, barbary ape" },
                { img: "img/beauty-4465397_640.jpg", label: "Item 8, beauty" },
                { img: "img/bike-1534902_640.jpg", label: "Item 8, bike" },
                { img: "img/castle-4873097_640.jpg", label: "Item 8, castle" }
            ]
        }, {
            name: "Item 9",
            radios: [
                { img: "img/cat-3169476_640.jpg", label: "Item 9, cat" },
                { img: "img/sea-4747601_640.jpg", label: "Item 9, sea" },
                { img: "img/city-4490237_640.jpg", label: "Item 9, city" }
            ]
        }, {
            name: "Item 10",
            radios: [
                { img: "img/cat-4864605_640.jpg", label: "Item 10, cat" },
                { img: "img/eye-4572820_640.jpg", label: "Item 10, eye" },
                { img: "img/flowering-cherry-4806091_640.jpg", label: "Item 10, flowering cherry" },
                { img: "img/pear-blossom-4853103_640.jpg", label: "Item 10, pear blossom" }
            ]
        }, {
            name: "Item 11",
            radios: [
                { img: "img/gallo-4870245_640.jpg", label: "Item 11, cgalloat" },
                { img: "img/lighthouse-4846854_640.jpg", label: "Item 11, lighthouse" },
                { img: "img/winter-4830285_640.jpg", label: "Item 11, winter" },
                { img: "img/night-4854108_640.jpg", label: "Item 11, night" }
            ]
        },
    ];

    const menuHeading = document.getElementById("menu-heading");
    menuHeading.innerText = `List menu contains ${items.length} items`;

    const menu = document.getElementById("menu");
    for (let i = 0; i < items; i++) {
        menu.options[i].label = items[i].name;
    }

    menu.onchange = () => {
        updateItem(menu.value);
    };

    updateItem(menu.value);

    function updateItem(name) {
        const item = getItem(name);
        for (let i = 1; i <= 4; i++) {
            const colId = `radio-${i}-col`;
            const colElement = document.getElementById(colId);

            if (i <= item.radios.length) {
                colElement.classList.remove("d-none");

                const radio = item.radios[i - 1];

                const imgId = `radio-${i}-img`;
                const imgElement = document.getElementById(imgId);
                imgElement.src = radio.img;

                const labelId = `radio-${i}-label`;
                const labelElement = document.getElementById(labelId);
                labelElement.innerText = radio.label;
            } else {
                colElement.classList.add("d-none");
            }
        }
    }

    function getItem(name) {
        return items.find(item => item.name === name);
    }
}());