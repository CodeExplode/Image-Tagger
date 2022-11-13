# Image-Tagger
A super simple image viewer with the ability to tag images, search by tags, and mark clipping regions for AI training purposes

![preview image](ImageTagger_v1.png)

Controls:
Left/Right to scroll images, or click on the edges
Space to enter/exit gallery slideshow mode (Escape also exits)
Mouse click to pan, mouse wheel to zoom

Drag in more than one image to begin a batch. Dragging in more images adds to the batch.

Implemented:
* Gallery functionality
* Full-screen slideshow with timer setting
* Interpolation options

Not Implemented:
* Efficient loading of images as needed. Dragging in a large number of images will try to load them all at once and possibly run out of memory.
* Tagging
* Searching Tags
* AI Data Clipping Regions
* Saving/Loading the database
* Removing images from the current batch
* WebP support, GIF playback
