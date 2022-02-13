class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = {
            picture: 200,
            photo: 50,
            item: 250,
        }
        this.listOfArticles = [];
        this.guests = [];
    }
    addArticle(articleModel, articleName, quantity) {
        const formatArticleModel = articleModel.toLowerCase();
        if (!this.possibleArticles[formatArticleModel]) {
            throw new Error('This article model is not included in this gallery!');
        }
        const article = this.listOfArticles.find(x => x.articleName === articleName && x.articleModel === formatArticleModel);
        if (article) {
            article.quantity += quantity;
        } else {
            this.listOfArticles.push({
                articleModel: formatArticleModel,
                articleName,
                quantity,
            });
        }

        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`
    }
    inviteGuest(guestName, personality) {
        let points = personality === 'Vip' ? 500 : personality === 'Middle' ? 250 : 50;
        if (this.guests.some(x => x.guestName === guestName)) {
            throw new Error(`${guestName} has already been invited.`);

        } else {
            this.guests.push({
                guestName,
                points,
                purchaseArticle: 0,
            });

        }
        return `You have successfully invited ${guestName}!`;
    }
    buyArticle(articleModel, articleName, guestName) {
        const article = this.listOfArticles.find(x => x.articleName === articleName && x.articleModel === articleModel);
        const formatArticleModel = articleModel.toLowerCase();
        const guest = this.guests.find(x => x.guestName === guestName);
        if (!article) {
            throw new Error('This article is not found.');
        }
        if (article.quantity <= 0) {
            return `The ${articleName} is not available.`;
        }
        if (!guest) {
            return `This guest is not invited.`;
        }
        const price = this.possibleArticles[formatArticleModel];
        const guestMoney = guest.points;
        if (price > guestMoney) {
            return `You need to more points to purchase the article.`;

        } else {
            guest.points -= price;
            guest.purchaseArticle++;
            article.quantity--;
        }
        return `${guestName} successfully purchased the article worth ${price} points.`;
    }
    showGalleryInfo(criteria) {
        if (criteria == 'article') {
            const info = [];
            info.push('Articles information:');
            for (const article of this.listOfArticles) {
                info.push(`${article.articleModel} - ${article.articleName} - ${article.quantity}`);
            }
            return info.join('\n');
        } else if (criteria == 'guest') {
            const info = [];
            info.push('Guests information:');
            for (const guest of this.guests) {
                info.push(`${guest.guestName} - ${guest.purchaseArticle}`);
            }
            return info.join('\n');
        }
    }
}