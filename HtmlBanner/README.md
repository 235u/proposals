# HTML 5 Banner

See [job details](docs/job-details.pdf) (one-time project, fixed-price), as posted on March 2, 2020, within `Front-End Development`, asking for a mix of experience and value in `HTML5`, `HTML` and `CSS`, including following images posted as attachments:

- [Artboard 2](src/HtmlBanner.Web/wwwroot/img/artboard-2.png)
- [Artboard 3](src/HtmlBanner.Web/wwwroot/img/artboard-3.png)
- [Artboard 4](src/HtmlBanner.Web/wwwroot/img/artboard-4.png)

## Asked questions

### Do you have any questions about the job description?

> The 3 designs are attached.

Could you provide this designs in a format like Adobe Photoshop (`*.psd`) / Illustrator (`*.ai`), with multiple layers (at least one for the text, to be removed from the background image and replaced with `HTML` text). Or as raster images (``*.png`) but without text and with detailed font info? (Not necessary if the current [solution](#solution) already meets your requirements.)

> The text and CTA will need to be animated [...]

How do you want the text to be animated? 

"CTA" means "Call to Action", represented by the "Get a free quote" button? Do you want this button to be a link?

> the 3 banners must loop between the slides.

Sliding from the right to the left (transitioning within 0.6 seconds, easing-in-out, after 5 seconds interval) in a loop (2-3-4-2-3-...) is OK?

### Do you have suggestions to make this project run successfully?

I'd fix the spelling on the first slide (`Artboard 2.png`, "Protect yourself again**st** HMRC tax investigations.") and replace the background image with a more appropriate one (currently showing two ladies laughing - what's so funny about tax investigations?), adjusting its contrast (compare to `Artboard 4.png`).

Please note that I'd need some JavaScript too (for sliding, pausing on hover, etc.).

### What questions do you have about the project?

Integration of the banner (on a / your website) is not part of this project, right? 

According to Upwork you have 3 jobs posted (including 1 job being open) with a 0% hire rate, could you explain that (the zero-percent hire rate)?

### What past project or job have you had that is most like this one and why?

See https://www.235u.net (the sliders).

## Solution

Live at https://html-banner.azurewebsites.net, using [Bootstrap's Carousel](https://getbootstrap.com/docs/4.4/components/carousel/):

