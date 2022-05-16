import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { getAllAlbums } from '../api/data.js';

const catalogTemplate = (albums, userToken) => html`
<section id="catalogPage">
    <h1>All Albums</h1>

    ${albums.length > 0
    ? 
    albums.map(album => albumTemplate(album, userToken))
    :
    noAlbums
    }
    
</section>
`;
const noAlbums = html`
<p>No Albums in Catalog!</p>
`;

const albumTemplate = (album, userToken) => html`
<div class="card-box">
    <img src=${album.imgUrl}>
    <div>
        <div class="text-center">
            <p class="name">Name: ${album.name}</p>
            <p class="artist">Artist: ${album.artist}</p>
            <p class="genre">Genre: ${album.genre}</p>
            <p class="price">Price: $${album.price}</p>
            <p class="date">Release Date: ${album.releaseDate}</p>
        </div>
        ${userToken
         ? 
        html`
        <div class="btn-group">
            <a href="/details/${album._id}" id="details">Details</a>
        </div>`
        :
        nothing
        }
        
    </div>
</div>`;

export async function catalogPage(ctx) {
    const albums = await getAllAlbums();
    const userToken = ctx.user()?.token;
    ctx.render(catalogTemplate(albums, userToken));
}