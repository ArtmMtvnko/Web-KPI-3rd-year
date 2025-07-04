// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: binance.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from binance.proto</summary>
public static partial class BinanceReflection {

  #region Descriptor
  /// <summary>File descriptor for binance.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static BinanceReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg1iaW5hbmNlLnByb3RvIk0KF0JpbmFuY2VSZXNwb25zZVByb3RvYnVmEg4K",
          "BnN0cmVhbRgBIAEoCRIiCgRkYXRhGAIgASgLMhQuQmluYW5jZURhdGFQcm90",
          "b2J1ZiJpChNCaW5hbmNlRGF0YVByb3RvYnVmEg4KBnN5bWJvbBgBIAEoCRIT",
          "CgtwcmljZUNoYW5nZRgCIAEoCRIaChJwcmljZUNoYW5nZVBlcmNlbnQYAyAB",
          "KAkSEQoJbGFzdFByaWNlGAQgASgJYgZwcm90bzM="));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::BinanceResponseProtobuf), global::BinanceResponseProtobuf.Parser, new[]{ "Stream", "Data" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::BinanceDataProtobuf), global::BinanceDataProtobuf.Parser, new[]{ "Symbol", "PriceChange", "PriceChangePercent", "LastPrice" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class BinanceResponseProtobuf : pb::IMessage<BinanceResponseProtobuf>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<BinanceResponseProtobuf> _parser = new pb::MessageParser<BinanceResponseProtobuf>(() => new BinanceResponseProtobuf());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<BinanceResponseProtobuf> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::BinanceReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public BinanceResponseProtobuf() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public BinanceResponseProtobuf(BinanceResponseProtobuf other) : this() {
    stream_ = other.stream_;
    data_ = other.data_ != null ? other.data_.Clone() : null;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public BinanceResponseProtobuf Clone() {
    return new BinanceResponseProtobuf(this);
  }

  /// <summary>Field number for the "stream" field.</summary>
  public const int StreamFieldNumber = 1;
  private string stream_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Stream {
    get { return stream_; }
    set {
      stream_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "data" field.</summary>
  public const int DataFieldNumber = 2;
  private global::BinanceDataProtobuf data_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public global::BinanceDataProtobuf Data {
    get { return data_; }
    set {
      data_ = value;
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as BinanceResponseProtobuf);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(BinanceResponseProtobuf other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Stream != other.Stream) return false;
    if (!object.Equals(Data, other.Data)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Stream.Length != 0) hash ^= Stream.GetHashCode();
    if (data_ != null) hash ^= Data.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Stream.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Stream);
    }
    if (data_ != null) {
      output.WriteRawTag(18);
      output.WriteMessage(Data);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Stream.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Stream);
    }
    if (data_ != null) {
      output.WriteRawTag(18);
      output.WriteMessage(Data);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Stream.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Stream);
    }
    if (data_ != null) {
      size += 1 + pb::CodedOutputStream.ComputeMessageSize(Data);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(BinanceResponseProtobuf other) {
    if (other == null) {
      return;
    }
    if (other.Stream.Length != 0) {
      Stream = other.Stream;
    }
    if (other.data_ != null) {
      if (data_ == null) {
        Data = new global::BinanceDataProtobuf();
      }
      Data.MergeFrom(other.Data);
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Stream = input.ReadString();
          break;
        }
        case 18: {
          if (data_ == null) {
            Data = new global::BinanceDataProtobuf();
          }
          input.ReadMessage(Data);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Stream = input.ReadString();
          break;
        }
        case 18: {
          if (data_ == null) {
            Data = new global::BinanceDataProtobuf();
          }
          input.ReadMessage(Data);
          break;
        }
      }
    }
  }
  #endif

}

[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class BinanceDataProtobuf : pb::IMessage<BinanceDataProtobuf>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<BinanceDataProtobuf> _parser = new pb::MessageParser<BinanceDataProtobuf>(() => new BinanceDataProtobuf());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<BinanceDataProtobuf> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::BinanceReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public BinanceDataProtobuf() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public BinanceDataProtobuf(BinanceDataProtobuf other) : this() {
    symbol_ = other.symbol_;
    priceChange_ = other.priceChange_;
    priceChangePercent_ = other.priceChangePercent_;
    lastPrice_ = other.lastPrice_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public BinanceDataProtobuf Clone() {
    return new BinanceDataProtobuf(this);
  }

  /// <summary>Field number for the "symbol" field.</summary>
  public const int SymbolFieldNumber = 1;
  private string symbol_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Symbol {
    get { return symbol_; }
    set {
      symbol_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "priceChange" field.</summary>
  public const int PriceChangeFieldNumber = 2;
  private string priceChange_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string PriceChange {
    get { return priceChange_; }
    set {
      priceChange_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "priceChangePercent" field.</summary>
  public const int PriceChangePercentFieldNumber = 3;
  private string priceChangePercent_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string PriceChangePercent {
    get { return priceChangePercent_; }
    set {
      priceChangePercent_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "lastPrice" field.</summary>
  public const int LastPriceFieldNumber = 4;
  private string lastPrice_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string LastPrice {
    get { return lastPrice_; }
    set {
      lastPrice_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as BinanceDataProtobuf);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(BinanceDataProtobuf other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Symbol != other.Symbol) return false;
    if (PriceChange != other.PriceChange) return false;
    if (PriceChangePercent != other.PriceChangePercent) return false;
    if (LastPrice != other.LastPrice) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Symbol.Length != 0) hash ^= Symbol.GetHashCode();
    if (PriceChange.Length != 0) hash ^= PriceChange.GetHashCode();
    if (PriceChangePercent.Length != 0) hash ^= PriceChangePercent.GetHashCode();
    if (LastPrice.Length != 0) hash ^= LastPrice.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Symbol.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Symbol);
    }
    if (PriceChange.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(PriceChange);
    }
    if (PriceChangePercent.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(PriceChangePercent);
    }
    if (LastPrice.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(LastPrice);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Symbol.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Symbol);
    }
    if (PriceChange.Length != 0) {
      output.WriteRawTag(18);
      output.WriteString(PriceChange);
    }
    if (PriceChangePercent.Length != 0) {
      output.WriteRawTag(26);
      output.WriteString(PriceChangePercent);
    }
    if (LastPrice.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(LastPrice);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Symbol.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Symbol);
    }
    if (PriceChange.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(PriceChange);
    }
    if (PriceChangePercent.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(PriceChangePercent);
    }
    if (LastPrice.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(LastPrice);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(BinanceDataProtobuf other) {
    if (other == null) {
      return;
    }
    if (other.Symbol.Length != 0) {
      Symbol = other.Symbol;
    }
    if (other.PriceChange.Length != 0) {
      PriceChange = other.PriceChange;
    }
    if (other.PriceChangePercent.Length != 0) {
      PriceChangePercent = other.PriceChangePercent;
    }
    if (other.LastPrice.Length != 0) {
      LastPrice = other.LastPrice;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Symbol = input.ReadString();
          break;
        }
        case 18: {
          PriceChange = input.ReadString();
          break;
        }
        case 26: {
          PriceChangePercent = input.ReadString();
          break;
        }
        case 34: {
          LastPrice = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Symbol = input.ReadString();
          break;
        }
        case 18: {
          PriceChange = input.ReadString();
          break;
        }
        case 26: {
          PriceChangePercent = input.ReadString();
          break;
        }
        case 34: {
          LastPrice = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
