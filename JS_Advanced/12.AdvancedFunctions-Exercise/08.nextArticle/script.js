function getArticleGenerator(articles) {
    let [...currentArticles] = articles;
    let contentElement = document.querySelector('body #content');
    return () => {
        if (currentArticles.length) {
            let articleElement = document.createElement('article');
            articleElement.textContent = currentArticles.shift();
            contentElement.appendChild(articleElement);
        }
    }
}

