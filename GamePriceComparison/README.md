# Simple Steam game price comparison web tool using API

See [job details](docs/job-details.pdf) (one-time project, fixed price), as posted on December 20, 2019 within `Full Stack Development`, asking for expertise in `HTML`, `JavaScript`, `JSON API`.

## Description

> The idea is to provide data so that it can be used to publish on a news website

Sounds like a one-way ticket / throw-away application. How much data do you want to provide? And how often? Once?

> to show how expensive UK gaming is compared to other places.

That's the ultimate goal? Representing a hypothesis (to be proven right or wrong by real-world data analysis), or the final conclusion (being quite obvious when comparing United Kingdom and Sierra Leone, e.g.)?

> The data will be pulled using https://steamapi.xpaw.me/

The data won't be pulled from a third-party "static page that is automatically generated from" an [endpoint](https://partner.steamgames.com/doc/webapi/ISteamWebAPIUtil#GetSupportedAPIList) of the [Steamwork Web API](https://partner.steamgames.com/doc/webapi_overview), which "is [also] used to build this [official] documentation".

Memo: The https://xpaw.me/ is beautiful.

> I need a basic webpage tool to populate current prices of steam games in Uk, Russia and Argentina

Note that this functionality is not part of the official Web API, see:

- Stackoverflow, [How to get the price of an app in Steam WebAPI?](https://stackoverflow.com/questions/13784059/how-to-get-the-price-of-an-app-in-steam-webapi)
- Official Team Fortress Wiki, [Rough documentation for the storefront API](https://wiki.teamfortress.com/wiki/User:RJackson/StorefrontAPI#Known_methods) - exposed via [Big Picture mode](https://support.steampowered.com/kb_article.php?ref=5006-ASLN-3202&l=english).

Do you need the current prices of all games available on Steam? That's more than **80K** titles, see [app-list.json](docs/app-list.json) (taking 5+ MiB), returned by the [GetAppList](https://partner.steamgames.com/doc/webapi/ISteamApps#GetAppList) endpoint.

Note that

- each and every title requires at least one additional request for pricing;
- the oficcially unsupported API required might be limited to n requests per unit of time;
- every title has an initial price and often one discount price (e.g. 20% off), the latter mutating over time, various packages/bundles and DLCs not considered;
- some titles (e.g. specific editions) are unavailable for some countries (on Steam).
 
> and something to show which country has the cheapest price for the games.

Something like highlighting the cheapest price for a specific title?

Note that prices have different currencies, which can be converted to one base currency (e.g. pound sterling) for comparison, nominally, ignoring the [purchasing power parity](https://en.wikipedia.org/wiki/Purchasing_power_parity) (PPP) and cultural specifics.

Also note that "cheap" does not neccessarily mean "high price-performance ratio", being a va

> Some basic filters should be added also.

Please explain how these "basic filters" are supposed

> to show how expensive UK gaming is compared to other places.

Keep in mind that the ability to filter on game title requires all the titles to be prefetched. 

## Proof of concept

<a href="https://https://price-comparison.azurewebsites.net">
  <img src="docs/prototype.png" alt="Prototype" width="800">
</a>

Live at https://price-comparison.azurewebsites.net, taking about 2 seconds to load, without any optimizations (12 requests to 3 different APIs, on the back-end, in sequence, without caching, etc.)

## Proposal

1. Review the prototype (don't review the source code behind, not before the ) and read the documentation.
2. Hire, approving the first milestone (Proof of concept).

> I can provide further details as required

1. Provide ALL the details you can.
2. Clarify given questions.
3. Negotiate next milestones, based on further proposals and indefinite estimates.
4. …
5. Redistribute the functionality between back- and front-end, targeting a JavaScript-only solution (for client-side execution)?