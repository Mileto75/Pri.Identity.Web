
let vue = new Vue({
    el: "#app",
    data: {
        pageTitle: "Our first Vue app",
        quote: "",
        loading: true,
        categoriesLoaded: false,
        quoteLoaded: false,
        categories: [],
        selectedCategory: null,
    },
    created: async function () {
        this.getCategories();
    },
    methods: {
        getCategories: async function () {
            this.loading = true;
            this.quoteLoaded = false;
            let result = await fetch("https://api.chucknorris.io/jokes/categories")
                .then(response => response.json())
                .then(data => {
                    this.loading = false;
                    this.quoteLoaded = true;
                    return data;
                })
                .catch(error => console.log(error));
            this.categories = result;
            this.categoriesLoaded = true;
            
        },
        getQuoteByCategory: async function () {
            const url = "https://api.chucknorris.io/jokes/random?category=" + this.selectedCategory;
            console.log(url);
            this.loading = true;
            let result = await fetch(url)
                .then(response => response.json())
                .then(data => {
                    this.loading = false;
                    return data.value;
                })
                .catch(error => console.log(error))
            this.quote = result;
            this.quoteLoaded = true;
        },
    },
});