# Command Pattern Replay — Oyun Programlama I

**Öğrenci:** Serdar Çetinkaya  
**Öğrenci numarası:** 20251603012  
**Unity sürümü:** 6000.6.3f1

## Kontroller

- **W, A, S, D:** Oyuncuyu 2D düzlemde bir adım taşır.
- **Z:** Son hareket komutunu geri alır ve replay listesinden çıkarır.
- **R:** Kalan hareket komutlarını başlangıç konumundan sırayla oynatır.

## Uygulama

- `ICommand`: `Execute` ve `Undo` işlemlerini tanımlayan sözleşme.
- `MoveCommand`: Oyuncunun önceki konumunu kaydedip hareketi uygular veya geri alır.
- `Player`: Komutları çalıştırır, undo yığınını ve replay listesini yönetir.
- `Awake`: Her yeni oyun başladığında başlangıç konumunu alır ve iki geçmişi sıfırlar.
- `UndoLastCommand`: Geri alınan son komutu hem undo yığınından hem replay listesinden çıkarır.
- `Replay`: Geçmişte kalan komutları başlangıç konumundan oynatır; replay sırasında komutları yeniden kaydetmez.

Açmak için bu klasörü Unity Hub'dan proje olarak seçin. Oyun `Assets/Scenes/SampleScene.unity` sahnesinden başlar.
