export class UrlHelper {
    #url;

    constructor(url) {
        this.#url = this.#cleanUrl(url ?? window.location.href);
    }

    getUrl = () => this.#url;

    addQueryString = (key, value) => {
        if (value) {
            const url =  new URL(this.#url);
            url.searchParams.append(key, value);
            this.#url = url.toString();
        }
    }

    #cleanUrl = (url) => url.split('?')[0];
}