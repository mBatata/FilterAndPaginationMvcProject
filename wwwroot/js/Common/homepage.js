import { UrlHelper } from './urlhelper.js';

export class HomePage {
    static #filterButtonsSelector = "button[data-action='filter']";
    static #paginatorButtonsSelector = "button[data-action='paginator'][data-pagenumber]";
    
    static #firstAndLastNameSelector = "input[name='FirstAndLastNameFilter']";
    static #sortBySelector = "select[name='SortBy']";
    static #extraInformationSelector = "input[name='ExtraInformationFilter']";

    static #pageQueryStringKey = "page";
	static #firstAndLastNameQueryStringKey = "firstAndLastName";
	static #sortByQueryStringKey = "sortBy";
	static #extraInformationQueryStringKey = "extraInformation";

    static init = () => {
        debugger;
        const searchFilterButtons = document.querySelectorAll(this.#filterButtonsSelector);
        const paginatorButtons = document.querySelectorAll(this.#paginatorButtonsSelector);

        if (searchFilterButtons.length > 0) {
            searchFilterButtons.forEach(button => button.addEventListener("click", this.#onFilterOrPaginatorClick));
        }

        if (paginatorButtons.length > 0) {
            paginatorButtons.forEach(button => button.addEventListener("click", this.#onFilterOrPaginatorClick));
        }
    }

    static #onFilterOrPaginatorClick = (event) => {
        const urlHelper = new UrlHelper();

        if (event.target.dataset.pagenumber) {
            urlHelper.addQueryString(this.#pageQueryStringKey, event.target.dataset.pagenumber);
        }

        urlHelper.addQueryString(this.#firstAndLastNameQueryStringKey, document.querySelector(this.#firstAndLastNameSelector).value);
        urlHelper.addQueryString(this.#sortByQueryStringKey, document.querySelector(this.#sortBySelector).value);
        urlHelper.addQueryString(this.#extraInformationQueryStringKey, document.querySelector(this.#extraInformationSelector).value);
        
        window.location.href = urlHelper.getUrl();
    }
}