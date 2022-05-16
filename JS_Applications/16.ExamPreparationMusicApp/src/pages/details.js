import { html, nothing } from '../../node_modules/lit-html/lit-html.js';
import { getById } from '../api/data.js';


const detailsTemplate = (album, user) => html`
<section id="detailsPage">
    <div class="wrapper">
        <div class="albumCover">
            <img src=${album.imgUrl}>
        </div>
        <div class="albumInfo">
            <div class="albumText">

                <h1>Name: ${album.name}</h1>
                <h3>Artist: ${album.artist}</h3>
                <h4>Genre:${album.genre}</h4>
                <h4>Price: $${album.price}</h4>
                <h4>Date: ${album.releaseDate}</h4>
                <p>Description: ${album.description}</p>
            </div>

            ${ user.id == album._ownerId
            ? 
            html`
            <div class="actionBtn">
                <a href="/edit/${album._id}" class="edit">Edit</a>
                <a href="/remove/${album._id}" class="remove">Delete</a>
            </div>`
            :
            nothing
            }
            
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const album = await getById(ctx.params.id);
    const user = ctx.user();
    ctx.render(detailsTemplate(album, user));
}