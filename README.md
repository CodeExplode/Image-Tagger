# Image-Tagger
A super simple image viewer with the ability to tag images, search by tags, and define clipping regions for AI training purposes

![preview image](ImageTagger_v5.png)

Controls:
* Left/Right to scroll images, or click on the edges
* Space to enter/exit gallery slideshow mode (Escape also exits)
* Mouse click to pan, mouse wheel to zoom
* Drag in more than one image to begin a batch. Dragging in more images adds to the batch.
* Alt disables maintaining aspect ratio when resizing the training area by the corners

Implemented:
* Tagging
* Searching images by tags
* Saving/Loading the database of image locations, image tags, and image training regions
* Definable regions for AI training
* Gallery functionality
* Full-screen slideshow with speed setting
* Interpolation options
* Somewhat efficient handling of large volumes of images (dragging in tens of thousands may take a minute)

Not Implemented:
* Removing images from the current batch
* Removing images from the database (can be done manually with a text editor)
* Negative search terms
* WebP support, GIF playback
