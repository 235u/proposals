# Simple Steam game price comparison web tool using API

See [job details](docs/job-details.pdf) (one-time project, fixed price), as posted on December 20, 2019, within `Full Stack Development`, asking for expertise in `HTML`, `JavaScript`, and `JSON API`.

## Proof of concept

Live at https://price-comparison.azurewebsites.net,

<a href="https://price-comparison.azurewebsites.net">
  <img src="docs/prototype.png" alt="Prototype" width="640">
</a>

taking about 2 seconds to load, without any optimizations (12 requests to 3 different APIs, on the back-end, in sequence, without caching, etc.)

Price conversions are done using [reference exchange rates](https://www.ecb.europa.eu/stats/policy_and_exchange_rates/euro_reference_exchange_rates) from the ECB (European Central Bank), not available for argentine pesos (replacing Argentina with Mexico, using mexican pesos).

## Proposal

1. Review the prototype and read the documentation, highlighting some complexity.
2. Hire, approving the first milestone ("Proof of concept").

> I can provide further details as required

3. Provide ALL the details you can.
4. Clarify following questions.
5. Negotiate the next milestones, based on further proposals and (indefinite by nature) estimates.
6. …
7. Redistribute the functionality between back- and front-end, targeting a JavaScript-only solution (for client-side execution)?

## Description

> The idea is to provide data so that it can be used to publish on a news website

It sounds like a [one-way ticket](https://youtu.be/D4y_acTR0MY) (aka throw-away application). How much data do you want to provide? And how often?

Once, for a single article?

Always, like the short stock market overview in the navigations bars of The New York Times [landing page](https://www.nytimes.com) and the [business section](https://www.nytimes.com/section/business), and/or the [full market overview](https://markets.on.nytimes.com/research/markets/overview/overview.asp)?

Data in which form? Via aditional JSON web API, as a facade, mashing up multiple APIs, aggregating the data?

> to show how expensive UK gaming is compared to other places.

That's the ultimate goal? Representing a hypothesis (to be proven right or wrong by real-world data analysis), or the conclusion (being quite obvious when comparing the United Kingdom with Sierra Leone, instead of the United Arab Emirates)?

> The data will be pulled using https://steamapi.xpaw.me/

The data won't be pulled from a third-party "static page that is automatically generated from" an [endpoint](https://partner.steamgames.com/doc/webapi/ISteamWebAPIUtil#GetSupportedAPIList) of the [Steamwork Web API](https://partner.steamgames.com/doc/webapi_overview), which "is [also] used to build this [official] documentation".

Memo: https://xpaw.me is beautiful.

> I need a basic webpage tool to populate current prices of steam games in Uk, Russia and Argentina

Note that this functionality is not part of the [official API](https://partner.steamgames.com/doc/api), see:

- Stackoverflow, [How to get the price of an app in Steam WebAPI?](https://stackoverflow.com/questions/13784059/how-to-get-the-price-of-an-app-in-steam-webapi)
- Official Team Fortress Wiki, [Rough documentation for the storefront API](https://wiki.teamfortress.com/wiki/User:RJackson/StorefrontAPI#Known_methods) - exposed via [Big Picture mode](https://support.steampowered.com/kb_article.php?ref=5006-ASLN-3202&l=english).

Do you need the current prices of all the games available on Steam? That's more than **80K**  titles (see [app-list.json](docs/app-list.json), returned by the [GetAppList](https://partner.steamgames.com/doc/webapi/ISteamApps#GetAppList) endpoint and taking 5+ MiB), being mutable - changing its properties (like title and discount) over time.

Note that

- every title requires at least one additional request for pricing;
- the [officially unsupported API](https://wiki.teamfortress.com/wiki/User:RJackson/StorefrontAPI) as the officially supported public API might be limited to `n` requests per unit of time. 

See [official documentation](https://partner.steamgames.com/doc/webapi_overview#2):

> If you're a publisher, then Steam also provides a partner-only Web API server hosted at https://partner.steam-api.com. The intent of this service is to have higher availability than the public host […]
 
Also note that

- some titles have an initial price and some of them a different final price (after discount, e.g. 20% off), the latter mutating over time;
- some titles are free-to-play (free-to-start), some are entirely free (of charge);
- some titles (or packages) are not available in some countries (for sale on Steam);
- various [bundles](https://partner.steamgames.com/doc/store/application/bundles), [packages](https://partner.steamgames.com/doc/store/application/packages), [DLCs](https://partner.steamgames.com/doc/store/application/dlc) and in-game-products are not, or might not be considered;
- Steam titles (including bundles, packages and DLCs) distributed outside of Steam as keys, retailed at lower price (see [Kinguin.net](https://www.kinguin.net)), gifted, rewarded, bundled with hardware, etc. are not considered.

> and something to show which country has the cheapest price for the games.

Something like highlighting the cheapest price for a specific title? Something to be expressend in concrete numbers and/or graphically, using charts? 

Note that prices are given in different currencies, which can be converted to one base currency (e.g. pound sterling) for comparison, nominally, ignoring the [purchasing power parity](https://en.wikipedia.org/wiki/Purchasing_power_parity) (PPP) and cultural specifics (like fundamental resistance against copyright).

Also note that initial prices (being the final prices on launch, sometimes, considering betas and early access prices, etc.) try to match locally specific price ranges, pretty-printed as 1199.00 or 29.99 (psychological barriers), being broken by conversion (and "discounts" in whole percents as well).

This may sound trivial, but "cheap" is a vague, highly subjective characteristic, in comparison with the less subjective "high price-performance ratio" (according to the "I'm not rich enough to buy cheap things" proverb).

> Some basic filters should be added also.

Please explain how these "basic filters" are supposed

> to show how expensive UK gaming is compared to other places.

Keep in mind that the ability to filter on game title requires all game titles (available in English, bound to unique app IDs) to be prefetched. 

## Backlog

A breakdown of additional work to be done, in form of an **un**ordered list of requirements: 

- refactoring;
- performance optimization;
- specials (10 titles pushed by Steam);
- new releases (top 30 titles);
- bundle and package coverage,

to be reviewed and continued.

### Speculations

Depending on project scope and budget:

- selection of displayed sections: specials, top sellers, and new releases;
- selection of displayed fields: initial and final prices, in base and/or native currency, actual discount in percent, categories, genres, and supported platforms (Windows, Mac, Linux);
- base currency selection (different to GBP);
- base country (as reference for specials, top sellers, and new releases, different to UK) and countries-to-compare selection;
- filtering (by title, discounts, categories, genres, and platforms);
- sorting (by column, ascending and descending);
- grouping,
- statistics (minimum, maximum, average, etc.),

**OR** mined data export - to do all of the above in Excel by hand.

