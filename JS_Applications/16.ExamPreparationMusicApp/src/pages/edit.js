import { html } from '../../node_modules/lit-html/lit-html.js';
import { editItem, getById } from '../api/data.js';

const editAlbumTemplate = (onSubmit, album) => html`
<section class="editPage">
    <form @submit=${onSubmit}>
        <fieldset>
            <legend>Edit Album</legend>

            <div class="container">
                <label for="name" class="vhide">Album name</label>
                <input id="name" name="name" class="name" type="text" .value=${album.name}>

                <label for="imgUrl" class="vhide">Image Url</label>
                <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" .value=${album.imgUrl}>

                <label for="price" class="vhide">Price</label>
                <input id="price" name="price" class="price" type="text" .value=${album.price}>

                <label for="releaseDate" class="vhide">Release date</label>
                <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" .value=${album.releaseDate}>

                <label for="artist" class="vhide">Artist</label>
                <input id="artist" name="artist" class="artist" type="text" .value=${album.artist}>

                <label for="genre" class="vhide">Genre</label>
                <input id="genre" name="genre" class="genre" type="text" .value=${album.genre}>

                <label for="description" class="vhide">Description</label>
                <textarea name="description" class="description" rows="10"
                    cols="10">${album.description}</textarea>

                <button class="edit-album" type="submit">Edit Album</button>
            </div>
        </fieldset>
    </form>
</section>`;

export async function editPage(ctx) {
    
    const album = await getById(ctx.params.id);
    ctx.render(editAlbumTemplate(onSubmit,album));

    async function onSubmit(e) {
        e.preventDefault();
        let form = Object.fromEntries(new FormData(e.currentTarget));
        for (const key in form) {
            if (!form[key].trim()) {
                alert('All fields are required');
                return;
            }
        }
        await editItem(album._id, form);
        ctx.page.redirect(`/details/${album._id}`);
    }
}