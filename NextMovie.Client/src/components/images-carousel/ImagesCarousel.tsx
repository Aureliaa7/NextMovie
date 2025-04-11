import { Carousel } from 'react-bootstrap';

interface ImagesCarouselProps {
  imagesPaths: string[];
  altString: string;
}

function ImagesCarousel(props: ImagesCarouselProps) {
  const { imagesPaths, altString } = props;
  return (
    <Carousel>
      {imagesPaths.length > 0 ? (
        imagesPaths.map((imageUrl, index) => (
          <Carousel.Item key={index}>
            <img
              className="d-block w-100"
              src={imageUrl}
              alt={`${altString} Image ${index + 1}`}
            />
          </Carousel.Item>
        ))
      ) : (
        <Carousel.Item>
          <img
            className="d-block w-100"
            src="https://via.placeholder.com/800x400"
            alt="Placeholder Image"
          />
        </Carousel.Item>
      )}
    </Carousel>
  );
}

export default ImagesCarousel;
