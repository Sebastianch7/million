import { Property } from "@/core/entities/Property";
import Link from "next/link";

export default function PropertyCard({ property }: { property: Property }) {
  const images =
    property.images?.filter((img) => img.enabled) ||
    property.images ||
    [];

  const hasImages = images.length > 0;

  const carouselId = `carousel-${property.idProperty}`;

  return (
    <div className="card shadow-sm h-100">
      <div id={carouselId} className="carousel slide" data-bs-ride="carousel">
        <div className="carousel-inner">
          {hasImages ? (
            images.map((img, index) => (
              <div
                key={img.idPropertyImage}
                className={`carousel-item ${index === 0 ? "active" : ""}`}
              >
                <img
                  src={img.file || "https://cdn.millionluxury.com/image-resizing?image=https://maustorageprod.blob.core.windows.net/spinfileuat/Spin/Data/Estate/IMG/ceb693ad6b7643fc8c1be271d6a9c068.svg?v=740"}
                  className="d-block w-100"
                  alt={`Imagen ${index + 1}`}
                  style={{
                    height: "200px",
                    objectFit: "cover",
                    borderTopLeftRadius: "0.5rem",
                    borderTopRightRadius: "0.5rem",
                  }}
                />
              </div>
            ))
          ) : (
            <div className="carousel-item active">
              <img
                src="https://cdn.millionluxury.com/image-resizing?image=https://maustorageprod.blob.core.windows.net/spinfileuat/Spin/Data/Estate/IMG/ceb693ad6b7643fc8c1be271d6a9c068.svg?v=740"
                className="d-block w-100"
                alt="Sin imagen"
                style={{
                  height: "200px",
                  objectFit: "contain",
                  padding: "10px",
                  borderTopLeftRadius: "0.5rem",
                  borderTopRightRadius: "0.5rem",
                  backgroundColor: "#000000ff",
                }}
              />
            </div>
          )}
        </div>

        {hasImages && images.length > 1 && (
          <>
            <button
              className="carousel-control-prev"
              type="button"
              data-bs-target={`#${carouselId}`}
              data-bs-slide="prev"
            >
              <span className="carousel-control-prev-icon" aria-hidden="true"></span>
              <span className="visually-hidden">last</span>
            </button>
            <button
              className="carousel-control-next"
              type="button"
              data-bs-target={`#${carouselId}`}
              data-bs-slide="next"
            >
              <span className="carousel-control-next-icon" aria-hidden="true"></span>
              <span className="visually-hidden">next</span>
            </button>
          </>
        )}
      </div>

      <span
        className="position-absolute top-0 end-0 m-2 px-2 py-1 bg-light text-secondary rounded small border"
        style={{ opacity: 0.9 }}
      >
        {property.year}
      </span>
      <div className="card-body d-flex flex-column justify-content-between">
        <h5 className="card-title mb-1">{property.name}</h5>
        <p className="card-text text-muted small mb-2">{property.address}</p>

        <p className="text-dark fw-bold fs-5 mb-3">
          ${property.price.toLocaleString("es-CO")}
        </p>

        <Link
          href={`/property/${property.idProperty}`}
          className="btn btn-outline-dark btn-sm w-100 mt-auto mb-3"
        >
          See details
        </Link>
        <div
        className="position-absolute bottom-0 end-0 text-secondary small p-1"
        style={{ opacity: 0.7 }}
      >
        <small>{property.codeInternal}</small>
      </div>
      </div>
    </div>
  );
}
