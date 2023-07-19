namespace GzipVerify
{
    public interface ISampleCompression
    {
        byte[] GzipEncode(byte[] data);
        byte[] GzipDecode(byte[] compressedData);
    }
}